using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoPaymentPlugin.APIModels.Response
{
    public class ClientModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("discount")]
        public int Discount { get; set; }

        [JsonProperty("percentage_cashback")]
        public int PercentageCashback { get; set; }

        [JsonProperty("balance_cashback")]
        public double BalanceCashback { get; set; }

        [JsonProperty("clientid")]
        public string Clientid { get; set; }

        [JsonProperty("pointid")]
        public object PointId { get; set; }
    }
}
