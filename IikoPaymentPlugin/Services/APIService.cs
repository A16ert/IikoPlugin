using IikoPaymentPlugin.APIModels.Response;
using IikoPaymentPlugin.HttpHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IikoPaymentPlugin.Services
{
    class APIService
    {
        #region singleton
        private static APIService _instance;

        public static APIService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new APIService();

            }

            return _instance;
        }

        private APIService() { }
        #endregion

        public async Task<ClientMainModel> GetClientInfo(string qrCode)
        {
            var response = await GetRequest(APIConfiguration.GET_CLIENT + qrCode);

            if (response.Status == "OK") return JsonConvert.DeserializeObject<ClientMainModel>(response.Result);
            else return new ClientMainModel() { Status = response.Status };
        }

        protected async Task<HttpResponse> PostRequest(string url, object model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                return await HttpRequest.ServicePostRequestJSON(url, json);
            }
            catch { return null; }
        }

        protected async Task<HttpResponse> GetRequest(string url)
        {
            try
            {
                return await HttpRequest.ServiceGetRequestJSON(url);


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected async Task<HttpResponse> DeleteRequest<T>(string url, object model) where T : class
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                return await HttpRequest.ServiceDeleteRequest(url, json);
            }
            catch { return null; }
        }
    }
}
