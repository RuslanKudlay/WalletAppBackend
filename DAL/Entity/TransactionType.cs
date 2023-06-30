using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL.Entity
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionType
    {
        Credit = 1,
        Payment = 2
    }
}
