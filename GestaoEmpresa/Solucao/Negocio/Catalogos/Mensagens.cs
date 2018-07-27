﻿using System;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Negocio.Catalogos
{
    public static class Mensagens
    {
        public static string DEVE_SER_INFORMADOS_NS_PARA_TODOS_OS_PRODUTOS(int quantidadeNS, int quantidadeProdutos)
        {
            return string.Format(
                "Devem ser informados números de série para todos os produtos.\n" +
                "Foram informados {0} números de séries, mas estão sendo operados {1} produtos.",
                quantidadeNS,
                quantidadeProdutos);
        }

        public static string NAO_HA_CONFIGURACOES_BANCO() 
        {
            return "Não há configurações de banco."; 
        }

        public static string X_FOI_CADASTRADO_COM_SUCESSO() 
        { 
            return "O produto foi cadastrado com sucesso!\n Atualize a tabela de produtos cadastrados para vê-lo."; 
        }

        public static string ERRO() 
        {
            return "Aconteceu um erro"; 
        }

        public static string NADA_FOI_ALTERADO() 
        {
            return "Nada foi alterado!"; 
        }

        public static string JA_EXISTE_UM_X_COM_ESSE_Y(string valor1, string valor2) 
        { 
            return string.Format("Já existe um(a) {0} cadastrado(a) com esse(a) {1}", valor1, valor2); 
        }

        public static string X_FOI_CADASTRADO_COM_SUCESSO(string valor)
        {
            return string.Format("{0} foi cadastrado(a) com sucesso!\n Atualize a tabela para vê-lo(a).", valor); 
        }

        public static string X_DEVE_SER_SELECIONADO(string valor) 
        { 
            return string.Format("{0} deve ser selecionado(a).", valor);
        }

        public static string X_DEVE_SER_INFORMADO(string valor)
        {
            return string.Format("{0} deve ser informado(a).", valor);
        }

        public static string TEM_CERTEZA_QUE_DESEJA_EXCLUIR_ESSE_X(string valor)
        {
            return string.Format("Tem certeza que deseja excluir esse {0}?", valor);
        }

        public static string X_NAO_PODE_SER_EXCLUIDO(string valor)
        {
            return string.Format("Esse {0} não pode ser excluído.", valor);
        }

        public static string O_X_FOI_EXCLUIDO_COM_SUCESSO(string valor)
        {
            return string.Format("O {0} foi excluído com sucesso.", valor);
        }

        public static string UM_PRODUTO_COM_O_NUMERO_DE_SERIE_X_JA_ESTA_EM_ESTOQUE(string numeroDeSerie)
        {
            return string.Format("Um produto com o número de série {0} já está em estoque!", numeroDeSerie);
        }

        public static string NAO_E_POSSIVEL_DAR_SAIDA_DO_NUMERO_DE_SERIE_X(string numeroDeSerie)
        {
            return string.Format("Um produto com o número de série {0} já está em estoque!", numeroDeSerie);
        }
    }
}
