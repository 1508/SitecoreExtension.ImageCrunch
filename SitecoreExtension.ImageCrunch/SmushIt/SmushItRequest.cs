using System;
using System.IO;
using System.Json;
using System.Net.Http;
using System.Threading.Tasks;
using SitecoreExtension.ImageCrunch.SmushIt.Responses;

namespace SitecoreExtension.ImageCrunch.SmushIt
{
    public class SmushItRequest
    {
        
        public static Entities.SmushItResponse SmushIt(Stream stream)
        {
            var client = new HttpClient();
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(stream), "\"files\"", "empty");

            HttpResponseMessage postAsync = client.PostAsync("http://www.smushit.com/ysmush.it/ws.php", content).Result;

            SmushItResponse jsonResult = null;
            if (postAsync.IsSuccessStatusCode)
            {
                string stringResult = postAsync.Content.ReadAsStringAsync().Result;

                var dynamicResut = JsonValue.Parse(stringResult);

                if (!dynamicResut.ContainsKey("error"))
                {
                    jsonResult = postAsync.Content.ReadAsAsync<SmushItResponse>().Result;
                }
                else
                {
                    throw new Exception(string.Format("Error: {0}", dynamicResut.GetValue("error").ReadAs<string>()));
                }
            }
            else
            {
                return null;
            }

            HttpResponseMessage httpResponseMessage = client.GetAsync(jsonResult.Dest, HttpCompletionOption.ResponseHeadersRead).Result;

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return null;
            }

            Stream result = httpResponseMessage.Content.ReadAsStreamAsync().Result;

            var smushItObject = new Entities.SmushItResponse();
            smushItObject.FileStream = result;
            smushItObject.Format = Path.GetExtension(jsonResult.Dest);

            return smushItObject;
        }
    }
}