using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Library
{
    public class APIConsumer
    {
        public async Task<List<IntervalData>> ConsumeAPI()
        {

            
            List<IntervalData> returnValue = null;
            using (var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var apiBaseUri = ConfigurationManager.AppSettings["ApiBaseUri"];
                client.BaseAddress = new Uri(apiBaseUri);
                client.Timeout = new TimeSpan(0, 10, 0);
                var responseTask =  client.GetAsync("values");
                
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<IntervalData>>();
                    readTask.Wait();

                    returnValue = readTask.Result;
                }
            }
            return returnValue;

        }

    }
}
