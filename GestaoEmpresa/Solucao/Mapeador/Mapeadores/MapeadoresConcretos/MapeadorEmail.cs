using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos
{
    public class MapeadorEmail : MapeadorPadraoEntidadeRelacionalUmParaMuitos<Email>
    {
        public override string Tabela => "EMAILS";
    }
}
