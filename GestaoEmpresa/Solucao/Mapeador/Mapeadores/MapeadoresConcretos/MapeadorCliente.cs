using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos
{
    public class MapeadorCliente : MapeadorPadraoVigencia<Cliente>
    {
        public override string Tabela => "CLIENTES";
    }
}
