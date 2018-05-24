using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System.Data;
using System.Reflection;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos
{
	public abstract class ValidadorPadrao<TEntidade> : IDisposable
		where TEntidade : class, new()
	{
		#region Atributos

		public string ModuloOrigem { get; set;  }

		public string FuncionalidadeOrigem { get; set; }

		public string ObjetoValidado { get; set; }

		//public string PropriedadeValidada { get;}

		#endregion

		public void ValideRegrasBasicas() { }

		public abstract void ValideRegrasEspecificas();
	}
}
