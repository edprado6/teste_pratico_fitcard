using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TesteFitcard.UI.RestClient.Interfaces;

namespace TesteFitcard.UI.RestClient.Services
{
    public class CorreiosClient : ICorreiosClient
    {
        private string _urlBaseApi { get; set; }
        protected string url { get; set; }
        private IConfigurationRoot _config { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>        
        public CorreiosClient()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            _urlBaseApi = _config["urlsApi:urlBaseApi"];

            url = "correios";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        public dynamic BuscaEndereco(string cep) {

            string urlResource = _urlBaseApi + _config["urlsApi:" + url] + "/buscaendereco/" + cep;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(urlResource).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var data = JsonConvert.DeserializeObject(stringData);
                    return data;
                }
                catch (Exception e) {

                    return stringData;
                }
            }
        }
    }
}
