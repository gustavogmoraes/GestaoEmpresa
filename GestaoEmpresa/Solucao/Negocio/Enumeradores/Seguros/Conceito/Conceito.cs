using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito
{
    public class Conceito : TypeSafeEnum<Conceito, EnumConceitos>
    {
        public static readonly Conceito Produto = new Conceito(EnumConceitos.PRODUTO, "Produto");
        public static readonly Conceito Interacao = new Conceito(EnumConceitos.INTERACAO, "Interação");
        public static readonly Conceito Colaborador = new Conceito(EnumConceitos.COLABORADOR, "Colaborador");
        public static readonly Conceito Cliente = new Conceito(EnumConceitos.CLIENTE, "Cliente");
        public static readonly Conceito SolicitacaoDeAtendimento = new Conceito(EnumConceitos.SOLICITACAO_DE_ATENDIMENTO, "Solicitação de atendimento");
        public static readonly Conceito OrdemDeServico = new Conceito(EnumConceitos.ORDEM_DE_SERVICO, "Ordem de serviço");

        public Conceito(EnumConceitos indicador, string nome)
            : base((int)indicador, nome)
        {
        }
    }
}
