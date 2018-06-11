﻿using System;

namespace GS.GestaoEmpresa.Solucao.Negocio.Catalogos
{
    public static class Mensagens
    {
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
    }
}
