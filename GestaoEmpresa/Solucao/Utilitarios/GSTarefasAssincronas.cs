using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
    public static class GSTarefasAssincronas
    {
        public static void ExecuteTarefaAssincrona(Action acao)
        {
            Task.Run(() =>
            {
                acao.Invoke();
            });
        }
    }
}
