
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bok.Models
{
    public class BankEntryDTO
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public StateEnum state { get; set; }
        public BankEntry bankEntry { get; }
        public string originalString { get; }
        public enum StateEnum
        {
            FINE, DUPLICATE, BROKEN,
            UNVERIFIED
        }
        public BankEntryDTO(StateEnum state, BankEntry bankEntry, string originalString) {
            this.state = state;
            this.bankEntry = bankEntry;
            this.originalString = originalString;
        }
    }
}