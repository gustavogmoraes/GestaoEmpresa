using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client.Documents.Session;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioPadrao<T> : IDisposable
        where T : class, IConceito, IRavenDbDocument, new()
    {
        public int Insira(T item)
        {
            if (item.Codigo == 0)
            {
                item.Codigo = ObtenhaProximoCodigoDisponivel();
            }

            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                sessaoRaven.Store(item);
                sessaoRaven.SaveChanges();
            }

            return item.Codigo;
        }

        public T Consulte(int codigo)
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>().FirstOrDefault(x => x.Codigo == codigo);
            }
        }

        public IList<T> Consulte(Func<T, bool> filtro)
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>().Where(filtro).ToList();
            }
        }

        public IList<T> ConsulteTodos()
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor)
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>()
                    .Select(seletor)
                    .ToList()
                    .Cast<T>()
                    .ToList();
            }
        }

        public void Atualize(T item)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                var itemConsultado = sessaoRaven.Load<T>(item.Id);
                
                itemConsultado.GetType().GetProperties().ToList().ForEach(prop => 
                    prop.SetValue(itemConsultado, prop.GetValue(item)));

                sessaoRaven.SaveChanges();
            }
        }

        public void Exclua(int codigo)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                sessaoRaven.Query<T>()
                    .Where(x => x.Codigo == codigo)
                    .ToList()
                    .ForEach(x => sessaoRaven.Delete(x.Id));

                sessaoRaven.SaveChanges();
            }
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            using (var session = RavenHelper.OpenSession())
            {
                var listaDeCodigos = session.Query<T>()
                    .Select(x => x.Codigo)
                    .ToList()
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                if (!listaDeCodigos.Any())
                {
                    return 1;
                }

                var numerosFaltando = listaDeCodigos.EncontreInteirosFaltandoEmUmaSequencia();

                return numerosFaltando != null && numerosFaltando.Any()
                    ? numerosFaltando.Min()
                    : listaDeCodigos.Max() + 1;
            }
        }

        public void Dispose()
        {
        }
    }
}
