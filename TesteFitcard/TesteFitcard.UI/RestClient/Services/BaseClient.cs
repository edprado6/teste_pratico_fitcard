using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TesteFitcard.DominioViewModel;
using TesteFitcard.UI.RestClient.Interfaces;

namespace TesteFitcard.UI.RestClient.Services
{
    /// <summary>
    /// Classe que implementa os principais verbos de chamada a API (GET, POST, PUT e DELETE).
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseClient<TEntity> : IBaseClient<TEntity> where TEntity : class
    {
        private string _urlBaseApi { get; set; }

        private IConfigurationRoot _config { get; set; }

        /// <summary>
        /// Método construtor.
        /// </summary>        
        public BaseClient()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            _urlBaseApi = _config["urlsApi:urlBaseApi"];
        }

        /// <summary>
        /// Realiza uma chamada GET buscando um objeto pelo seu id.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(string url, string id)
        {
            string urlResource = _urlBaseApi + _config["urlsApi:" + url] + "/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(urlResource).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                TEntity data = JsonConvert.DeserializeObject<TEntity>(stringData);
                return data;
            }
        }


        /// <summary>
        /// Realiza uma chamada GET buscando um objeto pelo seu id.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseViewModel<TEntity> GetFiltro(string url, object filtro)
        {
            string urlResource = _urlBaseApi + _config["urlsApi:" + url] + "/" + _config["urlsApi:filtrar"];

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);
                var json = JsonConvert.SerializeObject(filtro);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsync(urlResource, content).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<ResponseViewModel<TEntity>>(stringData);                
                return data;
            }
        }

        /// <summary>
        /// Realiza a inserção de novos registros.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TEntity Post(string url, TEntity obj) {

            string urlResource = _urlBaseApi + _config["urlsApi:" + url];

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsync(urlResource, content).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    TEntity data = JsonConvert.DeserializeObject<TEntity>(stringData);
                    return data;
                }
                var erros = JsonConvert.DeserializeObject(stringData);
                return null;
            }
        }

        /// <summary>
        /// Realiza UPDATE em uma entidade.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public TEntity Put(string url, TEntity obj) {

            string urlResource = _urlBaseApi + _config["urlsApi:" + url];

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);
                var json = JsonConvert.SerializeObject(obj);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PutAsync(urlResource, content).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                TEntity data = JsonConvert.DeserializeObject<TEntity>(stringData);
                return data;
            }
        }

        /// <summary>
        /// Realiza a remoção de elementos.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        public void Delete(string url, string id) {

            string urlResource = _urlBaseApi + _config["urlsApi:" + url] + "/" + id;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);                
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.DeleteAsync(urlResource).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                TEntity data = JsonConvert.DeserializeObject<TEntity>(stringData);               
            }
        }

        /// <summary>
        /// Realiza uma chamada GET buscando um objeto pelo seu id.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetSelect(string url, object filtro)
        {
            string urlResource = _urlBaseApi + _config["urlsApi:" + url] + "/" + _config["urlsApi:select"];

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlResource);
                var json = JsonConvert.SerializeObject(filtro);
                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.PostAsync(urlResource, content).Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<SelectListItem>>(stringData);
                return data;
            }
        }
    }
}
