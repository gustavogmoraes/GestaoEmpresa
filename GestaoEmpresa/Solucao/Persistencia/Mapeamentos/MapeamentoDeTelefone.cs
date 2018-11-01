
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos
{
    public class MapeamentoDeTelefone : MapeamentoDeObjeto<Telefone>
    {
        public MapeamentoDeTelefone()
        {
            Tabela = "TELEFONES";

            Mapeia(x => x.Numero, "NUMERO");
            Mapeia(x => x.Descricao, "DESCRICAO");
            Mapeia(x => x.Principal, "PRINCIPAL");
        }
    }
}
