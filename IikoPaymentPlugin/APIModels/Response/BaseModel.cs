using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoPaymentPlugin.APIModels.Response
{
    public class BaseModel
    {
        [JsonProperty("error")]
        public ErrorModel Error { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class ErrorModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
