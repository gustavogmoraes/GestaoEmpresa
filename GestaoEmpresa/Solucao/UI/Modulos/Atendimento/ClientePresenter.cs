using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public class ClientePresenter : Presenter<Cliente, FrmCliente>
    {
        public ClientePresenter()
        {
            MapeieControle(x => x.Codigo, x => x.txtCodigo);
            MapeieControle(x => x.Status, x => x.toggleStatus);
            MapeieControle(x => x.CadastroPendente, x => x.toggleCadastroPendente);

            MapeieControle(x => x.Nome, x => x.txtNomeDoCliente);
            MapeieControle(x => x.DataDeNascimentoCriacao, x => x.txtDataNascimentoCriacao);
            MapeieControle(x => x.TipoDePessoa, x => x.cbTipoDePessoa);
            MapeieControle(x => x.RG, x => x.txtRG);
            MapeieControle(x => x.InscricaoEstadual, x => x.txtInscricaoEstadual);
            MapeieControle(x => x.InscricaoMunicipal, x => x.txtInscricaoMunicipal);
            MapeieControle(x => x.RazaoSocial, x => x.txtRazaoSocial);
            MapeieControle(x => x.RamoDoNegocio, x => x.txtRazaoSocial);
            MapeieControle(x => x.Observacao, x => x.txtObservacoes);

            MapeieControle(x => x.Telefones, x => x.gridTelefones);

        }
    }
}
