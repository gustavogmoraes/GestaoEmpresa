﻿using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos
{
    public class MapeadorDeInteracao : IDisposable
    {
        private string Tabela => "INTERACOES";

        private string Colunas => string.Join(", ", this.ColunasETiposDeDados.Keys);

        private Dictionary<string, Type> ColunasETiposDeDados
        =>
        new Dictionary<string, Type>()
        {
            {"CODIGO", typeof(int)},
            {"HORARIO", typeof(DateTime)},
            {"TIPO", typeof(bool)},
            {"DESCRICAO", typeof(string)},
            {"CODIGO_PRODUTO", typeof(int) },
            {"QUANTIDADE", typeof(int) },
            {"VALOR", typeof(decimal) },
            {"ATUALIZARVALORNOCATALOGO", typeof(bool)},
            {"ORIGEM", typeof(string) },
            {"DESTINO", typeof(string) }
        };

        private Interacao MonteRetorno(DataTable tabela, int linha)
        {
            var retorno = new Interacao();

            retorno.Codigo = int.Parse(tabela.Rows[linha]["CODIGO"].ToString());
            retorno.TipoInteracao = (EnumTipoInteracao)int.Parse(tabela.Rows[linha]["TIPO"].ToString());
            retorno.Descricao = tabela.Rows[linha]["DESCRICAO"] != DBNull.Value
                              ? tabela.Rows[linha]["DESCRICAO"].ToString()
                              : null;
            retorno.Produto = new ServicoDeProduto().Consulte(int.Parse(tabela.Rows[linha]["CODIGO_PRODUTO"].ToString()));
            retorno.QuantidadeInterada = int.Parse(tabela.Rows[linha]["QUANTIDADE"].ToString());
            retorno.ValorInteracao = decimal.Parse(tabela.Rows[linha]["VALOR"].ToString());
            retorno.AtualizarValorDoProdutoNoCatalogo = GSUtilitarios.ConvertaValorBooleano(tabela.Rows[linha]["ATUALIZARVALORNOCATALOGO"].ToString());
            retorno.Origem = tabela.Rows[linha]["ORIGEM"] != DBNull.Value
                           ? tabela.Rows[linha]["ORIGEM"].ToString()
                           : null;
            retorno.Destino = tabela.Rows[linha]["DESTINO"] != DBNull.Value
                            ? tabela.Rows[linha]["DESTINO"].ToString()
                            : null;
            retorno.Horario = (DateTime)tabela.Rows[linha]["HORARIO"];

            return retorno;
        }

        private string ObtenhaValoresInsercao(Interacao interacao)
        {
            return string.Format("{0}, CAST ('{1}' AS DATETIME2), {2}, '{3}', {4}, {5}, {6}, '{7}', '{8}', '{9}'",
                                 interacao.Codigo,
                                 GSUtilitarios.FormateDateTimePtBrParaBD(interacao.Horario),
                                 (int)interacao.TipoInteracao,
                                 interacao.Descricao ?? "NULL",
                                 interacao.Produto.Codigo,
                                 interacao.QuantidadeInterada,
                                 interacao.ValorInteracao,
                                 GSUtilitarios.ConvertaValorBooleano(interacao.AtualizarValorDoProdutoNoCatalogo),
                                 interacao.Origem ?? "NULL",
                                 interacao.Destino ?? "NULL");
        }

        public void Insira(Interacao interacao)
        {
            string ComandoSQL = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                              Tabela,
                                              Colunas,
                                              ObtenhaValoresInsercao(interacao));

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(ComandoSQL);
            }
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            int codigo;
            using (var GSBancoDeDados = new GSBancoDeDados())
                codigo = GSBancoDeDados.ObtenhaProximoCodigoDisponivel(Tabela, "INTERACOES");

            return codigo;
        }

        public Interacao Consulte(int codigo)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} " +
                                              "WHERE CODIGO = {2} ",
                                              Colunas,
                                              Tabela,
                                              codigo);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;

                return MonteRetorno(tabela, 0);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public List<Interacao> ConsulteTodasInteracoesPorProduto(int codigoProduto)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} " +
                                              "WHERE CODIGO_PRODUTO = {2} " +
                                              "ORDER BY HORARIO DESC",
                                              Colunas,
                                              Tabela,
                                              codigoProduto);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;


                var listaRetorno = new List<Interacao>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetorno(tabela, linha));
                }

                return listaRetorno;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public List<Interacao> ConsulteTodasAsInteracoes()
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} " +
                                              "ORDER BY HORARIO DESC",
                                              Colunas,
                                              Tabela);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;


                var listaRetorno = new List<Interacao>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetorno(tabela, linha));
                }

                return listaRetorno;
            }
            catch (System.Exception)
            {
                return null;
                throw;
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
        // ~MapeadorDeInteracao() {
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
