using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Validador.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base
{
    public abstract class ServicoHistoricoPadrao<TConceito, TValidador, TRepositorio> : IDisposable
        where TConceito : ObjetoComHistorico, IConceitoComHistorico, new()
        where TValidador : ValidadorPadrao<TConceito>, IDisposable, new()
        where TRepositorio : RepositorioHistoricoPadrao<TConceito>, IDisposable, new()
    {
        private TValidador _validador;
        protected TValidador Validador
        {
            get => _validador ?? (_validador = new TValidador());
            set => _validador = value;
        }

        protected TRepositorio _repositorio;
        protected TRepositorio Repositorio
        {
            get => _repositorio ?? (_repositorio = new TRepositorio());
            set => _repositorio = value;
        }

        public TConceito Consulte(int codigo)
        {
            return Repositorio.Consulte(codigo);
        }

        public TConceito Consulte(int codigo, DateTime data)
        {
            return Repositorio.Consulte(codigo, data);
        }

        public IList<TConceito> ConsulteTodos()
        {
            return Repositorio.ConsulteTodos();
        }

        public IList<DateTime> ConsulteVigencias(int codigo)
        {
            return Repositorio.ConsulteVigencias(codigo);
        }

        public int ObtenhaQuantidadeDeRegistros()
        {
            return Repositorio.ObtenhaQuantidadeDeRegistros();
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            return Repositorio.ObtenhaProximoCodigoDisponivel();
        }

        protected abstract Action AcaoSucessoValidacaoDeCadastro(TConceito item);

        protected abstract Action AcaoSucessoValidacaoDeEdicao(TConceito item);

        protected abstract Action AcaoSucessoValidacaoDeExclusao(int codigo);

        public IList<Inconsistencia> Salve(TConceito item, EnumTipoDeForm tipoDeForm)
        {
            item.Vigencia = DateTime.Now;
            var inconsistencias = new List<Inconsistencia>();

            switch (tipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    inconsistencias = Validador.ValideCadastro(item).ToList();
                    if (inconsistencias.Count == 0)
                    {
                        var acao = AcaoSucessoValidacaoDeCadastro(item);
                        if (acao != null) acao.Invoke();

                        Repositorio.Insira(item);
                    }

                    break;

                case EnumTipoDeForm.Edicao:
                    inconsistencias = Validador.ValideEdicao(item).ToList();
                    if (inconsistencias.Count == 0)
                    {
                        var acao = AcaoSucessoValidacaoDeEdicao(item);
                        if (acao != null) acao.Invoke();

                        Repositorio.Atualize(item);
                    }

                    break;
            }

            return inconsistencias;
        }

        public IList<Inconsistencia> Exclua(int codigo)
        {
            var inconsistencias = Validador.ValideExclusao(codigo);

            if (inconsistencias.Count == 0)
            {
                var acao = AcaoSucessoValidacaoDeExclusao(codigo);
                if (acao != null) acao.Invoke();

                Repositorio.Exclua(codigo);
            }


            return inconsistencias;
        }

        public void Dispose()
        {
            if (_validador != null)
                _validador.Dispose();

            if (_repositorio != null)
                _repositorio.Dispose();
        }
    }
}
