using System.ComponentModel;

namespace Dotz.Programa.Fidelidade.Domain.Enums
{
    public enum EDeliveryStatus
    {
        [Description("Troca em Separação")]
        ExchangeSeparation = 1,

        [Description("Troca enviada")]
        ExchangeSent = 2,

        [Description("Troca recebida")]
        ExchangeReceived = 3
    }
}
