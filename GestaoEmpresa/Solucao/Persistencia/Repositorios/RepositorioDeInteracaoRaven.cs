﻿using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeInteracaoRaven : RepositorioPadrao<Interacao>
    {
        public void MigreInteracaoParaRaven()
        {
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                var interacoes = repositorioDeInteracao.ConsulteTodasAsInteracoes().OrderBy(x => x.Codigo).ToList();
                interacoes.ForEach(x => Insira(x));
            }
        }

        public bool VerifiqueSeNumeroDeSerieExisteNoBanco(string numeroDeSerie)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Query<Interacao>().Where(x => x.InformaNumeroDeSerie && x.NumerosDeSerie.Count > 0)
                                                     .Any(x => x.NumerosDeSerie.Contains(numeroDeSerie));
            }
        }
    }
}