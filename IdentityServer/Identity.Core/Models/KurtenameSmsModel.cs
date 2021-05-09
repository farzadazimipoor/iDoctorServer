using Newtonsoft.Json;

namespace Identity.Core.Models
{
    public class KurtenameSmsModel
    {
        [JsonProperty(PropertyName = "messageText")]
        public string MessageText { get; set; }

        [JsonProperty(PropertyName = "destAddr")]
        public string DestAddr { get; set; }

        [JsonProperty(PropertyName = "sourceAddr")]
        public string SourceAddr { get; set; }

        [JsonProperty(PropertyName = "unicode")]
        public bool Unicode { get; set; }
    }

    public class KurtenameSmsResultModel
    {
        [JsonProperty(PropertyName = "status")]
        public double Status { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "messageId")]
        public string MessageId { get; set; }

        [JsonProperty(PropertyName = "deliveryStatusUrl")]
        public string DeliveryStatusUrl { get; set; }
    }
}
