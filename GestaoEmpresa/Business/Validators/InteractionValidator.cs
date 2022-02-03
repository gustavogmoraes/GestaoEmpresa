using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Business.Validators.Base;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using MoreLinq;

namespace GS.GestaoEmpresa.Business.Validators
{
    public class InteractionValidator : BaseValidator<Interaction>, IDisposable
    {
        #region Propriedades

        private Interaction _interaction { get; set; }

        private List<Inconsistencia> _inconsistenceList { get; set; }

        private RepositorioDeProduto _productRepository;
        private RepositorioDeProduto ProductRepository => _productRepository ??= new RepositorioDeProduto();

        private InteractionRepository _interactionRepository;
        private InteractionRepository InteractionRepository => _interactionRepository ??= new InteractionRepository();

        #endregion

        #region Implementação Padrão

        public override IList<Inconsistencia> ValidateCreate(Interaction item)
        {
            _interaction = item;
            _inconsistenceList = new List<Inconsistencia>();

            ValideRegraObrigatoriedades();
            ValideRegrasDeNumeroDeSerie();
            ValideRegraQuantidades();

            return _inconsistenceList;
        }

        // ToDo
        public override IList<Inconsistencia> ValidateUpdate(Interaction item)
        {
            return new List<Inconsistencia>();
        }

        //TODO
        public override IList<Inconsistencia> ValidateDelete(int code)
        {
            var interaction = InteractionRepository.Query(code);
            var allProductCodes = interaction.SubInteractions.Select(x => x.Product.Code).ToList();

            var interactionList = InteractionRepository.Query(x => 
                x.SubInteractions.Any(y => 
                    allProductCodes.Contains(y.Product.Code)));

            var lastInteractionWithThisProduct = interactionList.MaxBy(x => x.Time);

            var errorList = new List<Inconsistencia>();
            if (code != lastInteractionWithThisProduct.Code)
            {
                //errorList.Add(new Inconsistencia
                //{
                //    Modulo = "Controle de Estoque",
                //    Tela = "Cadastro de Interações",
                //    ConceitoValidado = "Interação",
                //    NomeDaPropriedadeValidada = "Interação",
                //    DescricaoDaPropriedadeValidada = "Interação",
                //    Mensagem = $"Não é possível deletar essa interação porque ela não " +
                //    $"é a última interação com o produto {interaction.Produto.Codigo} - {interaction.Produto.Nome}."
                //});
            }

            return errorList;
        }

        #endregion

        #region Regras de validação

        private void ValideRegraObrigatoriedades()
        {
            foreach (var subInteraction in _interaction.SubInteractions)
            {
                if (subInteraction.Product == null || subInteraction.Product.Code == 0)
                {
                    _inconsistenceList.Add(new Inconsistencia
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Produto",
                        DescricaoDaPropriedadeValidada = "Produto da entrada/saída",
                        Mensagem = Mensagens.X_DEVE_SER_SELECIONADO("Um produto")
                    });
                }

                if (_interaction.InteractionType != InteractionType.ExchangeBase && subInteraction.InteractedQuantity == 0)
                {
                    _inconsistenceList.Add(new Inconsistencia
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "QuantidadeInterada",
                        DescricaoDaPropriedadeValidada = "Quantidade movimentada do produto",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Uma quantidade de produto para movimentação")
                    });
                }

                if (string.IsNullOrEmpty(_interaction.Origin))
                {
                    _inconsistenceList.Add(new Inconsistencia
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Origem",
                        DescricaoDaPropriedadeValidada = "Origem",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Uma origem")
                    });
                }

                if (string.IsNullOrEmpty(_interaction.Destination))
                {
                    _inconsistenceList.Add(new Inconsistencia
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Destino",
                        DescricaoDaPropriedadeValidada = "Destino",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Um destino")
                    });
                }
            }
        }

        private void ValideRegrasDeNumeroDeSerie()
        {
            foreach (var subInteraction in _interaction.SubInteractions)
            {
                // Números incompativeis com a quantidade
                if (subInteraction.InformsSerialNumber && subInteraction.SerialNumbers.Count != subInteraction.InteractedQuantity)
                {
                    _inconsistenceList.Add(new Inconsistencia
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "NumerosDeSerie",
                        DescricaoDaPropriedadeValidada = "Lista de números de série",
                        Mensagem = Mensagens.DEVE_SER_INFORMADOS_NS_PARA_TODOS_OS_PRODUTOS(
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
                            when _interaction.InteractionType == InteractionType.Input:
                            _inconsistenceList.Add(new Inconsistencia
                            {
                                Modulo = "Controle de Estoque",
                                Tela = "Cadastro de Interações",
                                ConceitoValidado = "Interação",
                                NomeDaPropriedadeValidada = "NumerosDeSerie",
                                DescricaoDaPropriedadeValidada = "Lista de números de série",
                                Mensagem = Mensagens.UM_PRODUTO_COM_O_NUMERO_DE_SERIE_X_JA_ESTA_EM_ESTOQUE(serialNumber)
                            });
                            break;
                        case false 
                            when _interaction.InteractionType == InteractionType.Output:
                            _inconsistenceList.Add(new Inconsistencia
                            {
                                Modulo = "Controle de Estoque",
                                Tela = "Cadastro de Interações",
                                ConceitoValidado = "Interação",
                                NomeDaPropriedadeValidada = "NumerosDeSerie",
                                DescricaoDaPropriedadeValidada = "Lista de números de série",
                                Mensagem = Mensagens.NAO_E_POSSIVEL_DAR_SAIDA_DO_NUMERO_DE_SERIE_X(serialNumber)
                            });
                            break;
                    }
                }
            }
        }

        private void ValideRegraQuantidades()
        {
            foreach (var subInteraction in _interaction.SubInteractions)
            {
                var currentQuantity = ProductRepository.ConsulteQuantidade(subInteraction.Product.Code);
                var interactedQuantity = _interaction.InteractionType == InteractionType.Output
                    ? subInteraction.InteractedQuantity * -1 
                    : subInteraction.InteractedQuantity;

                var auxiliaryQuantity = (subInteraction.AuxiliaryQuantity ?? 0) * -1;
                if (currentQuantity + interactedQuantity + auxiliaryQuantity < 0)
                {
                    _inconsistenceList.Add(new Inconsistencia
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Produto",
                        DescricaoDaPropriedadeValidada = "Produto da entrada/saída",
                        Mensagem = "Essa interação deixaria o produto com quantidade abaixo de 0!"
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
