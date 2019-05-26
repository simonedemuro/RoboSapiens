using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RoboSapiens.Core.Services
{
    public class PythonService
    {
        string UserAgent { get; set; }
        string UserAgentValue { get; set; }

        public PythonService(string userAgent, string userAgentValue)
        {
            UserAgent = userAgent;
            UserAgentValue = userAgentValue;
        }

        public string GetReleases(string url)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(UserAgent, UserAgentValue);

                var response = httpClient.GetStringAsync(new Uri(url)).Result;

                return response;
            }
        }

        public static async void DownloadPageAsync(string url)
        {
            // ... Target page.
            string page = url;

            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);


                // ... Display the result.
                if (result != null &&
                    result.Length >= 50)
                {
                    Console.WriteLine(result.Substring(0, 50) + "...");
                }
            }
        }

    }
}
