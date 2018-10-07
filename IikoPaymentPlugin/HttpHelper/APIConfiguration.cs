using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoPaymentPlugin.HttpHelper
{
    public static class APIConfiguration
    {
        private static readonly string BASE_API_URL = "https://cashbox.ortezgroup.com/cashbox";

        public static readonly string GET_CLIENT = BASE_API_URL + "/client?clientid=";
    }
}
