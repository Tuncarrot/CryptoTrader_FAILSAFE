using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DogeHODLTrader
{
    class WebRequest
    {
        private const string URL = "https://api.binance.com";

        HttpClient client;
        
        public WebRequest()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // MAKE ENV FILE LATER
            client.DefaultRequestHeaders.Add("X-MBX-APIKEY", Constants.API_KEY);
        }

        public HttpResponseMessage SendRequest(string request)
        {
            return client.GetAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        }

        public dynamic CheckResponse(HttpResponseMessage response)
        {
            dynamic jsonObject = null;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                
            }
            else
            {
                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return jsonObject;
        }
        ~WebRequest()
        {
            client.Dispose();
        }
    }
}

