using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents.Linq;
using GS.GestaoEmpresa.Business.Services.Base;
using GS.GestaoEmpresa.Business.Validators;
using GS.GestaoEmpresa.Persistence.Repositories;

namespace GS.GestaoEmpresa.Business.Services
{
    public class InteractionService : BaseService<Interaction, InteractionValidator, InteractionRepository>, IDisposable
    {
        private static Expression<Func<Interaction, object>> SeletorInteracaoAterrissagem => x => new Interaction
        {
            //Codigo = x.Codigo,
            //TipoDeInteracao = x.TipoDeInteracao,
            //Produto = new Produto
            //{
            //    Codigo = x.Codigo, 
            //    Nome = x.Produto.Nome
            //},
            //QuantidadeInterada = x.QuantidadeInterada,
            //Origem = x.Origem,
            //Destino = x.Destino,
            //Finalidade = x.Finalidade,
            //Situacao = x.Situacao,
            //NumerosDeSerie = x.NumerosDeSerie,
            //HorarioProgramado = x.HorarioProgramado,
            //ValorInteracao = x.ValorInteracao,
        };

        private static Expression<Func<Interaction, object>>[] DefaultPropertiesToSearch => new Expression<Func<Interaction, object>>[] 
        {
            //x => x.Produto.Nome, x => x.Produto.CodigoDoFabricante, x => x.Produto.Codigo, x => x.Produto.CodigoDeBarras,
            //x => x.Destino, x => x.Origem, x => x.NumerosDeSerie
        };

        public List<Interaction> QueryAllInteractions()
        {
            return Repository.Query()
                .OrderByDescending(x => x.ScheduledTime)
                .ToList();
        }

        public bool CheckIfSerialNumberIsInDatabase(string serialNumber)
        {
            var interactionRepository = new InteractionRepository();

            return interactionRepository.CheckIfSerialNumberIsInDatabase(serialNumber);
        }

        public List<Interaction> QueryAllInteractionsByProduct(int productCode)
        {
            var interactionRepository = new InteractionRepository();

            return interactionRepository.Query(x => 
                x.SubInteractions.Any(y =>
                    y.Product.Code == productCode)).ToList();
        }

        public List<Interaction> QueryToLandingPage(string searchTerm = null)
        {
            if (searchTerm.IsNullOrEmpty())
            {
                return Repository.Query(searchTerm, DefaultPropertiesToSearch, SeletorInteracaoAterrissagem, int.MaxValue)
                    .OrderByDescending(x => x.ScheduledTime)
                    .ToList();
            }

            return Repository.Query(searchTerm, DefaultPropertiesToSearch, SeletorInteracaoAterrissagem)
                .OrderByDescending(x => x.ScheduledTime)
                .ToList();
        }

        private IList<Interaction> QueryBySerialNumber(string serialNumber)
        {
            var interactionRepo = new InteractionRepository();
            var result = interactionRepo.Query(interaction =>
                interaction.SubInteractions.Any(sub =>
                    sub.InformsSerialNumber &&
                    sub.SerialNumbers.Select(sn => sn.ToLowerInvariant()).Any(sn =>
                        sn.Contains(serialNumber.ToLowerInvariant()))));

            return result;
        }
        
        public bool CheckIfSerialNumberIsIntoTheInventory(string serialNumber)
        {
            var interactionList = QueryBySerialNumber(serialNumber);

            var inputNumbers = interactionList.Count(x => x.InteractionType == InteractionType.Input);
            var outputNumbers = interactionList.Count(x => x.InteractionType == InteractionType.Output);

            return inputNumbers > outputNumbers;
        }

        public new List<Inconsistencia> Delete(int interactionNumber)
        {
            using var productService = new ProductService();
            using var interactionValidator = new InteractionValidator();
            var interactionRepository = new InteractionRepository();

            var interaction = Query(interactionNumber);

            var productsQuantities = productService.ConsulteQuantidade(
                interaction.SubInteractions.Select(x => x.Product.Code).ToList());

            var errorList = interactionValidator.ValidateDelete(interactionNumber).ToList();
            if (errorList.Count > 0)
            {
                return errorList;
            }

            foreach (var subInteraction in interaction.SubInteractions)
            {
                var interactedQuantity = 0;
                var interactedAuxiliaryQuantity = 0;

                switch (interaction.InteractionType)
                {
                    case InteractionType.Input:
                        interactedQuantity = subInteraction.InteractedQuantity * (-1);
                        break;

                    case InteractionType.Output:
                        interactedQuantity = subInteraction.InteractedQuantity;
                        break;

                    case InteractionType.ExchangeBase:
                        // Input
                        interactedQuantity = subInteraction.InteractedQuantity * (-1);

                        // Output
                        interactedAuxiliaryQuantity = subInteraction.AuxiliaryQuantity.GetValueOrDefault();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var newQuantity = productsQuantities[subInteraction.Product.Code] +
                                  interactedQuantity +
                                  interactedAuxiliaryQuantity;

                productService.AltereQuantidadeDeProduto(productsQuantities[subInteraction.Product.Code], newQuantity);
            }

            interactionRepository.Delete(interactionNumber);

            return errorList;
        }

        protected override Action CreateValidationSucceeded(Interaction interaction)
        {
            return () =>
            {
                using var productService = new ProductService();
                var interactedQuantity = 0;
                var interactedAuxiliaryQuantity = 0;

                foreach (var subInteraction in interaction.SubInteractions)
                {
                    switch (interaction.InteractionType)
                    {
                        case InteractionType.Input:
                            interactedQuantity = subInteraction.InteractedQuantity;
                            break;
                        case InteractionType.Output:
                            interactedQuantity = subInteraction.InteractedQuantity * (-1);
                            break;
                        case InteractionType.ExchangeBase:
                            // Input
                            interactedQuantity = subInteraction.InteractedQuantity;

                            // Output
                            interactedAuxiliaryQuantity = subInteraction.AuxiliaryQuantity.GetValueOrDefault() * (-1);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    var queriedProduct = productService.Query(subInteraction.Product.Code, false);

                    // In this case we update the product with the new value
                    if (subInteraction.UpdateUnitaryPriceAtProductCatalog)
                    {
                        var productPrice = interaction.InteractionType == InteractionType.Input
                            ? queriedProduct.PurchasePrice
                            : queriedProduct.SalePrice;

                        // If the price is different we must create a new revision
                        if (subInteraction.UnitaryPrice != productPrice.GetValueOrDefault())
                        {
                            if (interaction.InteractionType == InteractionType.Input)
                            {
                                queriedProduct.PurchasePrice = subInteraction.UnitaryPrice;
                                queriedProduct.CalculateSalePrice();
                            }
                            else
                            {
                                queriedProduct.SalePrice = subInteraction.UnitaryPrice;
                            }

                            productService.Save(queriedProduct, FormType.Update);
                        }
                    }

                    var inventoryQuantity = productService.ConsulteQuantidade(queriedProduct.Code);

                    productService.AltereQuantidadeDeProduto(queriedProduct.Code, inventoryQuantity + interactedQuantity + interactedAuxiliaryQuantity);
                }
            };
        }

        protected override Action UpdateValidationSucceeded(Interaction item)
        {
            return () =>
            {
                var interaction = item;
                if (interaction.Situation != "Devolvido") return;

                using var productService = new ProductService();
                foreach (var subInteraction in interaction.SubInteractions)
                {
                    var queriedProduct = productService.Query(subInteraction.Product.Code);
                    var quantity = productService.ConsulteQuantidade(queriedProduct.Code);

                    productService.AltereQuantidadeDeProduto(queriedProduct.Code,
                        quantity + subInteraction.InteractedQuantity);
                    productService.Dispose();
                }
            };
        }

        protected override Action DeleteValidationSucceeded(int code)
        {
            return () =>
            {
                
            };
        }
    }
}
