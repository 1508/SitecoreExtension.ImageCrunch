using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Sitecore;
using Sitecore.Diagnostics;
using SitecoreExtension.ImageCrunch.Entities;
using SitecoreExtension.ImageCrunch.Interfaces;

namespace SitecoreExtension.ImageCrunch.Kraken
{
    public class KrakenCruncher : ICruncher
    {
        public CrunchResult CrunchStream(Stream stream)
        {
            var client = new HttpClient();
            var content = new MultipartFormDataContent();

            var list = new List<KeyValuePair<string, JsonValue>>();

            JsonValue value = new JsonObject
            {
                {
                    "auth", new JsonObject
                    {
                        {
                            "api_key", Settings.ApiKey
                        },
                        {
                            "api_secret", Settings.ApiSecret

                        }
                    }
                    

                },
                {
                    "wait", true
                }
            };

            var stringContent = new StringContent(value.ToString());
            
            content.Add(stringContent, "woop");
            var streamContent = new StreamContent(stream);
            //streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            content.Add(streamContent, "file ", "it needed a file name");

            HttpResponseMessage postAsync = client.PostAsync("https://api.kraken.io/v1/upload", content).Result;

            Response jsonResult = null;
            if (postAsync.IsSuccessStatusCode)
            {
                string stringResult = postAsync.Content.ReadAsStringAsync().Result;

                var dynamicResult = JsonValue.Parse(stringResult);
                if (dynamicResult.ContainsKey("success") && dynamicResult["success"].ReadAs(false))
                {
                    jsonResult = postAsync.Content.ReadAsAsync<Response>().Result;
                }
                else
                {
                    throw new Exception(string.Format("Error: {0}", dynamicResult.GetValue("error").ReadAs<string>()));
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

            var returnObject = new Entities.CrunchResult();
            returnObject.FileStream = result;
            returnObject.Format = Path.GetExtension(jsonResult.Dest);

            return returnObject;
        }

        public decimal MaxImageSize
        {
            get
            {
                return int.MaxValue;
            }
        }
    }


}