using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Business.Validators.Base;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using MoreLinq;

namespace GS.GestaoEmpresa.Business.Validators
{
    public class InteractionValidator : BaseValidator<Interaction>, IDisposable
    {
        public InteractionValidator()
        {
            _productRepository = new ProductRepository();
            _interactionRepository = new InteractionRepository();
        }

        private Interaction Interaction { get; set; }

        private List<Error> ErrorList { get; set; }

        private readonly ProductRepository _productRepository;

        private readonly InteractionRepository _interactionRepository;

        #region Implementação Padrão

        public override IList<Error> ValidateCreate(Interaction item)
        {
            Interaction = item;
            ErrorList = new List<Error>();

            ValidateMandatory();
            ValidateSerialNumbers();
            ValidateQuantityRule();

            return ErrorList;
        }

        // ToDo
        public override IList<Error> ValidateUpdate(Interaction item)
        {
            return new List<Error>();
        }

        //TODO
        public override IList<Error> ValidateDelete(int code)
        {
            var interaction = _interactionRepository.Query(code);
            var allProductCodes = interaction.SubInteractions.Select(x => x.Product.Code).ToList();

            var interactionList = _interactionRepository.Query(x => 
                x.SubInteractions.Any(y => 
                    allProductCodes.Contains(y.Product.Code)));

            var lastInteractionWithThisProduct = interactionList.MaxBy(x => x.Time);

            var errorList = new List<Error>();
            if (code != lastInteractionWithThisProduct.Code)
            {
                //errorList.Add(new Error
                //{
                //    Module = "Controle de Estoque",
                //    View = "Cadastro de Interações",
                //    ValidatedConcept = "Interação",
                //    NameOfValidatedProperty = "Interação",
                //    ValidatedPropertyDescription = "Interação",
                //    Message = $"Não é possível deletar essa interação porque ela não " +
                //    $"é a última interação com o produto {interaction.Produto.Codigo} - {interaction.Produto.Nome}."
                //});
            }

            return errorList;
        }

        #endregion

        #region Regras de validação

        private void ValidateMandatory()
        {
            if (Interaction.InteractionType == null)
            {
                ErrorList.Add(new Error
                {
                    Module = "Storage",
                    View = "Interaction",
                    ValidatedConcept = "Interaction",
                    NameOfValidatedProperty = "InteractionType",
                    ValidatedPropertyDescription = "InteractionType",
                    Message = Mensagens.X_DEVE_SER_SELECIONADO("Um tipo de interação")
                });
            }

            if (string.IsNullOrEmpty(Interaction.Origin))
            {
                ErrorList.Add(new Error
                {
                    Module = "Controle de Estoque",
                    View = "Cadastro de Interações",
                    ValidatedConcept = "Interação",
                    NameOfValidatedProperty = "Origem",
                    ValidatedPropertyDescription = "Origem",
                    Message = Mensagens.X_DEVE_SER_INFORMADO("Uma origem")
                });
            }

            if (string.IsNullOrEmpty(Interaction.Destination))
            {
                ErrorList.Add(new Error
                {
                    Module = "Controle de Estoque",
                    View = "Cadastro de Interações",
                    ValidatedConcept = "Interação",
                    NameOfValidatedProperty = "Destino",
                    ValidatedPropertyDescription = "Destino",
                    Message = Mensagens.X_DEVE_SER_INFORMADO("Um destino")
                });
            }

            foreach (var subInteraction in Interaction.SubInteractions)
            {
                if (subInteraction.Product == null || subInteraction.Product.Code == 0)
                {
                    ErrorList.Add(new Error
                    {
                        Module = "Controle de Estoque",
                        View = "Cadastro de Interações",
                        ValidatedConcept = "Interação",
                        NameOfValidatedProperty = "Produto",
                        ValidatedPropertyDescription = "Produto da entrada/saída",
                        Message = Mensagens.X_DEVE_SER_SELECIONADO("Um produto")
                    });
                }

                if (Interaction.InteractionType != InteractionType.ExchangeBase && subInteraction.InteractedQuantity == 0)
                {
                    ErrorList.Add(new Error
                    {
                        Module = "Controle de Estoque",
                        View = "Cadastro de Interações",
                        ValidatedConcept = "Interação",
                        NameOfValidatedProperty = "QuantidadeInterada",
                        ValidatedPropertyDescription = "Quantidade movimentada do produto",
                        Message = Mensagens.X_DEVE_SER_INFORMADO("Uma quantidade de produto para movimentação")
                    });
                }
            }
        }

        private void ValidateSerialNumbers()
        {
            foreach (var subInteraction in Interaction.SubInteractions)
            {
                // Números incompativeis com a quantidade
                if (subInteraction.InformsSerialNumber && subInteraction.SerialNumbers.Count != subInteraction.InteractedQuantity)
                {
                    ErrorList.Add(new Error
                    {
                        Module = "Controle de Estoque",
                        View = "Cadastro de Interações",
                        ValidatedConcept = "Interação",
                        NameOfValidatedProperty = "NumerosDeSerie",
                        ValidatedPropertyDescription = "Lista de números de série",
                        Message = Mensagens.DEVE_SER_INFORMADOS_NS_PARA_TODOS_OS_PRODUTOS(
                            subInteraction.SerialNumbers.Count, subInteraction.InteractedQuantity)
                    });
                }

                if (subInteraction.SerialNumbers == null || subInteraction.SerialNumbers.Count == 0)
                {
                    return;
                }

                using var interactionService = new InteractionService();
                foreach (var serialNumber in subInteraction.SerialNumbers)
                {
                    if (!interactionService.CheckIfSerialNumberIsInDatabase(serialNumber)) continue;

                    var isItIntoTheInventory = interactionService.CheckIfSerialNumberIsIntoTheInventory(serialNumber);
                    switch (isItIntoTheInventory)
                    {
                        case true 
                            when Interaction.InteractionType == InteractionType.Input:
                            ErrorList.Add(new Error
                            {
                                Module = "Controle de Estoque",
                                View = "Cadastro de Interações",
                                ValidatedConcept = "Interação",
                                NameOfValidatedProperty = "NumerosDeSerie",
                                ValidatedPropertyDescription = "Lista de números de série",
                                Message = Mensagens.UM_PRODUTO_COM_O_NUMERO_DE_SERIE_X_JA_ESTA_EM_ESTOQUE(serialNumber)
                            });
                            break;
                        case false 
                            when Interaction.InteractionType == InteractionType.Output:
                            ErrorList.Add(new Error
                            {
                                Module = "Controle de Estoque",
                                View = "Cadastro de Interações",
                                ValidatedConcept = "Interação",
                                NameOfValidatedProperty = "NumerosDeSerie",
                                ValidatedPropertyDescription = "Lista de números de série",
                                Message = Mensagens.NAO_E_POSSIVEL_DAR_SAIDA_DO_NUMERO_DE_SERIE_X(serialNumber)
                            });
                            break;
                    }
                }
            }
        }

        private void ValidateQuantityRule()
        {
            foreach (var subInteraction in Interaction.SubInteractions)
            {
                var currentQuantity = _productRepository.QueryQuantity(subInteraction.Product.Code);
                var interactedQuantity = Interaction.InteractionType == InteractionType.Output
                    ? subInteraction.InteractedQuantity * -1 
                    : subInteraction.InteractedQuantity;

                var auxiliaryQuantity = (subInteraction.AuxiliaryQuantity ?? 0) * -1;
                if (currentQuantity + interactedQuantity + auxiliaryQuantity < 0)
                {
                    ErrorList.Add(new Error
                    {
                        Module = "Controle de Estoque",
                        View = "Cadastro de Interações",
                        ValidatedConcept = "Interação",
                        NameOfValidatedProperty = "Produto",
                        ValidatedPropertyDescription = "Produto da entrada/saída",
                        Message = "Essa interação deixaria o produto com quantidade abaixo de 0!"
                    });
                }
            }
        }

        #endregion

        #region Suporte à IDisposable
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ValidadorDeinteracao() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
