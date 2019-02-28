namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public class InformacoesConexaoBanco
    {
        public string Servidor { get; set; }

        public string NomeBanco { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        private EnumTipoDeBanco? _tipoDeBanco;

        public EnumTipoDeBanco TipoDeBanco
        {
            get => _tipoDeBanco ?? EnumTipoDeBanco.RAVENDB;
            set => _tipoDeBanco = value;
        }
    }
}
