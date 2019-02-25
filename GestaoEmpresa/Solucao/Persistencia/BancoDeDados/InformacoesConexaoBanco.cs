namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public class InformacoesConexaoBanco
    {
        public string Servidor { get; set; }

        public string NomeBanco { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string UrlRaven =>   /* local */ @"http://localhost:8080";
                                   /* servidor */ // @"http://192.168.15.250:8081";

        public string DatabaseRaven => "GestaoEmpresa";
    }
}
