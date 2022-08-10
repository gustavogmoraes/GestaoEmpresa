using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            ErrorList = new List<Error>();
        }

        private Product Product { get; set; }

        private Product PreviousProduct { get; set; }

        private List<Error> ErrorList { get; set; }

        private async Task ValidateRuleProductCannotBeDeleted(int productCode)
        {
            using var interactionService = new InteractionService();
            var interactionsByProduct = await interactionService.QueryAllInteractionsByProductAsync(productCode);

            if (interactionsByProduct.Count > 0)
            {
                ErrorList.Add(new Error
                {   
                    View = "Consulta de produtos",
                    ValidatedConcept = "Exclusão de product",
                    Message = Mensagens.X_NAO_PODE_SER_EXCLUIDO("product")
                });
            }
        }

        public List<Error> ValidateInitialCreation(Produto product)
        {
            var errorList = new List<Error>();

            using var productRepository = new RepositorioDeProduto();
            var queriedProduct = productRepository.Consulte(product.Codigo);

            if (queriedProduct != null && (queriedProduct.Codigo == product.Codigo || product.Nome == product.Nome))
            {
                errorList.Add(new Error
                {
                    Message = Mensagens.JA_EXISTE_UM_X_COM_ESSE_Y("Produto", "código ou nome")
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
                ErrorList.Add(new Error
                {
                    Module = "Controle de Estoque",
                    View = "Cadastro de Produtos",
                    ValidatedConcept = "Produto",
                    Message = Mensagens.NADA_FOI_ALTERADO
                });
            }
        }

        public void ValidateRuleProductMustHaveDifferentMakerCode()
        {
            var productRepo = new ProductRepository();
            var trimmedCode = Product.ManufacturerCode?.Trim();

            if (trimmedCode.IsNullOrEmpty())
            {
                return;
            }

            var queriedProduct = Task.Run(() => productRepo.QueryFirstAsync(x => x.ManufacturerCode == trimmedCode)).Result;
            if (queriedProduct.IsNotNull())
            {
                ErrorList.Add(new Error
                {
                    Module = "Controle de Estoque",
                    View = "Cadastro de Produtos",
                    ValidatedConcept = "Produto",
                    Message = $"Já existe um produto cadastrado com o Código do Fabricante " +
                        $"'{trimmedCode}'"
                });
            }
        }

        public override async Task<IList<Error>> ValidateCreateAsync(Product item)
        {
            Product = item;

            ValideRegraObrigatoriedades();
            ValidateRuleProductMustHaveDifferentMakerCode();

            return ErrorList;
        }

        public override async Task<IList<Error>> ValidateUpdateAsync(Product item)
        {
            Product = item;

            using var productService = new ProductService();
            PreviousProduct = await productService.QueryFirstAsync(item.Code, item.RevisionStartDateTime.AddSeconds(-1));

            ValidateRuleNothingHasChanged();

            return ErrorList;
        }

        public override async Task<IList<Error>> ValidateDeleteAsync(int code)
        {
            await ValidateRuleProductCannotBeDeleted(code);

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