using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DogeHODLTrader
{
    class WebRequest
    {
        HttpClient         client;

        public WebRequest(string URL)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");

        }

        public void AddAPIData(string API_NAME, string API_KEY)
        {
            client.DefaultRequestHeaders.Add(API_NAME, API_KEY);
        }

        public HttpResponseMessage SendRequest(string request)
        {
            return client.GetAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        }

        public bool CheckServerStatus(HttpResponseMessage response)
        {
            bool result = false;

            if ((int)response.StatusCode == Constants.SERVER_OK)
            {
                result = true;
            }

            return result;
        }

        public dynamic CheckResponse(HttpResponseMessage response)
        {
            dynamic jsonObject = null;
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
                jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(result);

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return jsonObject;
        }
        ~WebRequest()
        {
            client.Dispose();
        }
    }
}

