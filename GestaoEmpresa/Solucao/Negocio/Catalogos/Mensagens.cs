using System;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Negocio.Catalogos
{
    public static class Mensagens
    {
        public static string NAO_HA_CONFIGURACOES_BANCO => 
            "Não há configurações de banco.";

        public static string PRODUTO_FOI_CADASTRADO_COM_SUCESSO => "" +
            "O produto foi cadastrado com sucesso!\n Atualize a tabela de produtos cadastrados para vê-lo.";

        public static string ERRO => 
            "Aconteceu um erro";

        public static string NADA_FOI_ALTERADO => 
            "Nada foi alterado!";

        public static string TEM_CERTEZA_QUE_QUER_DAR_ENTRADA_SEM_VALOR => 
            "Você tem certeza que deseja dar entrada sem valor?";

        public static string JA_EXISTE_UM_X_COM_ESSE_Y(string valor1, string valor2) => 
            $"Já existe um(a) {valor1} cadastrado(a) com esse(a) {valor2}";

        public static string X_FOI_CADASTRADO_COM_SUCESSO(string valor) => 
            $"{valor} foi cadastrado(a) com sucesso!\n Atualize a tabela para vê-lo(a).";

        public static string X_DEVE_SER_SELECIONADO(string valor) => 
            $"{valor} deve ser selecionado(a).";

        public static string X_DEVE_SER_INFORMADO(string valor) => 
            $"{valor} deve ser informado(a).";

        public static string TEM_CERTEZA_QUE_DESEJA_EXCLUIR_ESSE_X(string valor) => 
            $"Tem certeza que deseja excluir esse {valor}?";

        public static string X_NAO_PODE_SER_EXCLUIDO(string valor) => 
            $"Esse {valor} não pode ser excluído.";

        public static string O_X_FOI_EXCLUIDO_COM_SUCESSO(string valor) => 
            $"O {valor} foi excluído com sucesso.";

        public static string UM_PRODUTO_COM_O_NUMERO_DE_SERIE_X_JA_ESTA_EM_ESTOQUE(string numeroDeSerie) => 
            $"Um produto com o número de série {numeroDeSerie} já está em estoque!";

        public static string NAO_E_POSSIVEL_DAR_SAIDA_DO_NUMERO_DE_SERIE_X(string numeroDeSerie) => 
            $"Não é possível dar saída de um produto com o número de série {numeroDeSerie}, pois o mesmo não está em estoque!";

        public static string DEVE_SER_INFORMADOS_NS_PARA_TODOS_OS_PRODUTOS(int quantidadeNS, int quantidadeProdutos) =>
            $"Devem ser informados números de série para todos os produtos.\n" +
            $"Foram informados {quantidadeNS} números de séries, mas estão sendo operados {quantidadeProdutos} produtos.";
    }
}
