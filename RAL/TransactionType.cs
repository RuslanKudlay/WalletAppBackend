using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RAL
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
    {
        Credit = 1,
        Payment = 2
    }
}
