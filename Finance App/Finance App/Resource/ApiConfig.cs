using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Finance_App.Entity;
using System.Text.Json;

namespace Finance_App.Resource
{
    public  class ApiConfig
    {
        public static string baseUrl = "https://financemanagementapi.azure-api.net/";

        private HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, ApiConfig.baseUrl + url);
            request.Headers.Add("Accept", "application/json");

            //start loading
            Finance_App.MainWindow.ShowLoading(true);
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            //stop loading
            Finance_App.MainWindow.ShowLoading(false);

            return responseMessage;
        }

        public async Task<HttpResponseMessage> PodtAsync(string url, Object data)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiConfig.baseUrl + url);
            request.Content = new StringContent(JsonSerializer.Serialize(data),Encoding.UTF8, "application/json");

            //start loading
            Finance_App.MainWindow.ShowLoading(true);
            HttpResponseMessage responseMessage = await client.SendAsync(request);
            //stop loading
            Finance_App.MainWindow.ShowLoading(false);

            return responseMessage;
        }
    }
}
