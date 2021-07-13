using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Business.Validators.Base;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using KellermanSoftware.CompareNetObjects;

namespace GS.GestaoEmpresa.Business.Validators
{
    public class ProductValidator : BaseValidator<Product>, IDisposable
    {
        public ProductValidator()
        {
            ErrorList = new List<Inconsistencia>();
        }

        private Product Product { get; set; }

        private Product PreviousProduct { get; set; }

        private List<Inconsistencia> ErrorList { get; set; }

        private void ValidateRuleProductCannotBeDeleted(int productCode)
        {
            using var interactionService = new InteractionService();
            var interactionsByProduct = interactionService.QueryAllInteractionsByProduct(productCode);

            if (interactionsByProduct.Count > 0)
            {
                ErrorList.Add(new Inconsistencia
                {   
                    Tela = "Consulta de produtos",
                    ConceitoValidado = "Exclusão de product",
                    Mensagem = Mensagens.X_NAO_PODE_SER_EXCLUIDO("product")
                });
            }
        }

        public List<Inconsistencia> ValidateInitialCreation(Produto product)
        {
            var errorList = new List<Inconsistencia>();

            using var productRepository = new RepositorioDeProduto();
            var queriedProduct = productRepository.Consulte(product.Codigo);

            if (queriedProduct != null && (queriedProduct.Codigo == product.Codigo || product.Nome == product.Nome))
            {
                errorList.Add(new Inconsistencia
                {
                    Mensagem = Mensagens.JA_EXISTE_UM_X_COM_ESSE_Y("Produto", "código ou nome")
                });
            }

            return errorList;   
        }

        private void ValideRegraObrigatoriedades()
        {
            //Nada ainda
        }

        private void ValidateRuleNothingHasChanged()
        {
            var compareLogic = new CompareLogic
            {
                Config = { MembersToIgnore = new List<string> { "RevisionStartDateTime", "QuantidadeEmEstoque" } }
            };
            // https://github.com/GregFinzer/Compare-Net-Objects/wiki/Ignoring-Members

            var result = compareLogic.Compare(PreviousProduct, Product);
            if (result.AreEqual)
            {
                ErrorList.Add(new Inconsistencia
                {
                    Modulo = "Controle de Estoque",
                    Tela = "Cadastro de Produtos",
                    ConceitoValidado = "Produto",
                    Mensagem = Mensagens.NADA_FOI_ALTERADO
                });
            }
        }

        public void ValidateRuleProductMustHaveDifferentMakerCode()
        {
            var productRepo = new ProductRepository();

            var queriedProduct = productRepo.Query(x => 
            x.ManufacturerCode.Trim() == Product.ManufacturerCode.Trim());
            if (queriedProduct.IsNotNull())
            {
                ErrorList.Add(new Inconsistencia
                {
                    Modulo = "Controle de Estoque",
                    Tela = "Cadastro de Produtos",
                    ConceitoValidado = "Produto",
                    Mensagem = $"Já existe um produto cadastrado com o Código do Fabricante " +
                        $"'{Product.ManufacturerCode.Trim()}'"
                });
            }
        }

        public override IList<Inconsistencia> ValidateCreate(Product item)
        {
            Product = item;

            ValideRegraObrigatoriedades();
            ValidateRuleProductMustHaveDifferentMakerCode();

            return ErrorList;
        }

        public override IList<Inconsistencia> ValidateUpdate(Product item)
        {
            Product = item;

            using var productService = new ProductService();
            PreviousProduct = productService.Query(item.Code, item.RevisionStartDateTime.AddSeconds(-1));

            ValidateRuleNothingHasChanged();

            return ErrorList;
        }

        public override IList<Inconsistencia> ValidateDelete(int code)
        {
            ValidateRuleProductCannotBeDeleted(code);

            return ErrorList;
        }

        #region IDisposable Support
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
        // ~ValidadorDeProduto() {
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