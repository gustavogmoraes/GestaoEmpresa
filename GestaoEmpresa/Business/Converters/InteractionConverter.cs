using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Business.Converters
{
    public class InteractionConverter
    {
        public Interaction Convert(Interacao old)
        {
            static InteractionType ConvertInteractionType(EnumTipoDeInteracao tipoDeInteracao) => tipoDeInteracao switch
            {
                EnumTipoDeInteracao.ENTRADA => InteractionType.Input,
                EnumTipoDeInteracao.SAIDA => InteractionType.Output,
                EnumTipoDeInteracao.BASE_DE_TROCA => InteractionType.ExchangeBase,
                _ => 0
            };

            var productConverter = new ProductConverter();

            var newObj = new Interaction
            {
                Code = old.Codigo,
                InteractionType = ConvertInteractionType(old.TipoDeInteracao),
                Origin = old.Origem,
                Destination = old.Destino,
                Goal = old.Finalidade,
                InvoiceNumber = old.NumeroDaNota,
                Situation = old.Situacao,
                Technician = old.Tecnico,
                ScheduledTime = old.HorarioProgramado,
                Time = old.Horario,
                Notes = old.Observacao,
                ReturnTime = old.HorarioDevolucao,
                SubInteractions = new List<SubInteraction>
                {
                    new()
                    {
                        InformsSerialNumber = old.InformaNumeroDeSerie,
                        SerialNumbers = old.NumerosDeSerie,
                        UpdateUnitaryPriceAtProductCatalog = old.AtualizarValorDoProdutoNoCatalogo,
                        Product = productConverter.Convert(old.Produto),
                        InteractedQuantity = old.QuantidadeInterada,
                        AuxiliaryQuantity = old.QuantidadeAuxiliar
                    }
                }
            };

            return newObj;
        }
    }
}
