using System.ComponentModel;

namespace Domain.Entities.Enums
{
    public enum StatusPedidoEnum
    {
        [Description("Pendente Armazem")]
        PendenteArmazem,
        [Description("Pendente Estoque")]
        PendenteEstoque,
        [Description("Aguardando Envio")]
        AguardandoEnvio,
        [Description("Em Trânsito")]
        EmTransito,
        [Description("Entregue")]
        Entregue
    }
}
