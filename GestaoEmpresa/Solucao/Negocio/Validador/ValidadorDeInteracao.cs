using System;
using System.Collections.Generic;
using System.Data;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador
{
    public class ValidadorDeInteracao : IDisposable
    {
        private Interacao _interacao { get; set; }

        private List<Inconsistencia> _listaDeInconsistencias { get; set; }

        public List<Inconsistencia> Valide(Interacao interacao)
        {
            _interacao = interacao;
            _listaDeInconsistencias = new List<Inconsistencia>();

            //Chame validações aqui
            
            ValideRegraObrigatoriedades();
            ValideRegrasDeNumeroDeSerie();

            return _listaDeInconsistencias;
        }

        private void ValideRegraObrigatoriedades()
        {
            if (_interacao.Produto == null || _interacao.Produto.Codigo == 0)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Produto",
                        DescricaoDaPropriedadeValidada = "Produto da entrada/saída",
                        Mensagem = Mensagens.X_DEVE_SER_SELECIONADO("Um produto")
                    });
            }

            if (_interacao.QuantidadeInterada == 0)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "QuantidadeInterada",
                        DescricaoDaPropriedadeValidada = "Quantidade movimentada do produto",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Uma quantidade de produto para movimentação")
                    });
            }

            if (string.IsNullOrEmpty(_interacao.Origem))
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Origem",
                        DescricaoDaPropriedadeValidada = "Origem",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Uma origem")
                    });
            }

            if (string.IsNullOrEmpty(_interacao.Destino))
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
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
        
        private void ValideRegrasDeNumeroDeSerie()
		{
			// Primeiro validamos se existe algum número de série na lista para evitar gastar processamento
			if _interacao.NumerosDeSerie.Count == 0
				return;
				
			using(var servicoDeInteracao = new ServicoDeInteracao())
			{
				foreach(numeroDeSerie in _interacao.NumerosDeSerie)
				{
					// Consultamos se o número de série existe para evitar gastar processamento
					if (MapeadorDeNumeroDeSerie().Consulte(numeroDeSerie) == null)
						continue;
					
					var estahEmEstoque = servicoDeInteracao.VerifiqueSeNumeroDeSerieEstahEmEstoque(numeroDeSerie);
					
					if (_interacao.TipoInteracao == EnumTiposDeInteracao.ENTRADA && estahEmEstoque)
					{
						_listaDeInconsistencias.Add(
							new Inconsistencia()
							{
								Modulo = "Controle de Estoque",
								Tela = "Cadastro de Interações",
								ConceitoValidado = "Interação",
								NomeDaPropriedadeValidada = "NumerosDeSerie",
								DescricaoDaPropriedadeValidada = "Lista de números de série",
								Mensagem = Mensagens.UM_PRODUTO_COM_O_NUMERO_DE_SERIE_X_JA_ESTA_EM_ESTOQUE(numeroDeSerie)
							});
					}
					
					if (_interacao.TipoInteracao == EnumTiposDeInteracao.SAIDA && !estahEmEstoque)
					{
						_listaDeInconsistencias.Add(
							new Inconsistencia()
							{
								Modulo = "Controle de Estoque",
								Tela = "Cadastro de Interações",
								ConceitoValidado = "Interação",
								NomeDaPropriedadeValidada = "NumerosDeSerie",
								DescricaoDaPropriedadeValidada = "Lista de números de série",
								Mensagem = Mensagens.NAO_E_POSSIVEL_DAR_SAIDA_DO_NUMERO_DE_SERIE_X(numeroDeSerie)
							});
					}
				}
			}
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
