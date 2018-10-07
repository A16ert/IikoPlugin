using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IikoPaymentPlugin.HttpHelper
{
    class HttpRequest
    {
        public static string HttpPost(string URI, NameValueCollection request)
        {
            string Parameters = string.Join("&", request.AllKeys.Select(key => key + "=" + request[key]).ToArray());
            WebRequest req = WebRequest.Create(URI);
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static async Task<string> MakePostRequest(string RequestUrl, byte[] Content)
        {
            //HttpClient httpClient = new HttpClient();
            HttpContent httpContent = new ByteArrayContent(Content);
            string mResponse = string.Empty;
            try
            {
                Console.WriteLine("Sending Request: " + RequestUrl + Content);
                HttpResponseMessage response = await new HttpClient().PostAsync(RequestUrl, httpContent).ConfigureAwait(false);
                mResponse = await response.RequestMessage.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine(hre.Message);
            }

            return (mResponse);
        }

        public static async Task<string> PostAsync(string uri, string data)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(data));

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            Console.Write("ResponseAsync=" + content);
            return await Task.Run(() => content);
        }

        public static async Task<string> ServicePostRequest(string url, NameValueCollection request)
        {
            string Parameters = string.Join("&", request.AllKeys.Select(key => key + "=" + request[key]).ToArray());
            string result = string.Empty;

            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(Parameters);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                client.Timeout = new TimeSpan(0, 0, 15);
                using (var response = await client.PostAsync(url, content))
                {
                    using (var responseContent = response.Content)
                    {
                        result = await responseContent.ReadAsStringAsync();
                        return result;
                    }
                }
            }
        }

        public static async Task<HttpResponse> ServicePostRequestJSON(string url, string json_request)
        {
            string result = string.Empty;
            string status = string.Empty;
            HttpResponse responseModel = new HttpResponse();

            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(json_request);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                client.Timeout = new TimeSpan(0, 0, 30);
                using (var response = await client.PostAsync(url, content))
                {
                    using (var responseContent = response.Content)
                    {
                        result = await responseContent.ReadAsStringAsync();
                        status = response.StatusCode.ToString();
                        responseModel.Result = result;
                        responseModel.Status = status;
                        return responseModel;
                    }
                }
            }
        }

        public static async Task<HttpResponse> ServiceGetRequestJSON(string url)
        {
            string result = string.Empty;
            string status = string.Empty;
            HttpResponse responseModel = new HttpResponse();
            using (var client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 15);
                using (var response = await client.GetAsync(url))
                {
                    using (var responseContent = response.Content)
                    {
                        result = await responseContent.ReadAsStringAsync();
                        status = response.StatusCode.ToString();
                        responseModel.Result = result;
                        responseModel.Status = status;
                        return responseModel;
                    }
                }
            }
        }

        public static async Task<HttpResponse> ServiceDeleteRequest(string url, string json_request)
        {
            string result = string.Empty;
            string status = string.Empty;

            HttpResponse responseModel = new HttpResponse();
            using (var client = new HttpClient())
            {
                HttpContent content = new StringContent(json_request);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                client.Timeout = new TimeSpan(0, 0, 15);
                using (var response = await client.DeleteAsync(url))
                {
                    using (var responseContent = response.Content)
                    {
                        result = await responseContent.ReadAsStringAsync();
                        status = response.StatusCode.ToString();
                        responseModel.Result = result;
                        responseModel.Status = status;
                        return responseModel;
                    }
                }
            }
        }
    }

    class HttpResponse
    {
        public string Result { set; get; }

        public string Status { set; get; }
    }
}
