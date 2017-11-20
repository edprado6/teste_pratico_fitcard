using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TesteFitcard.UI.RestClient;

namespace TesteFitcard.UI.Services
{
    public class ServiceBase
    {
        /// <summary>
        /// Realiza consulta a API buscando o token de acesso.
        /// </summary>
        /// <param name="configuracaoLoja"></param>
        protected async Task<BuscaToken> GetAccessToken()
        {
            var client = new HttpClient();
            var dadosToken = new BuscaToken();

            try
            {
                Dictionary<string, string> parametros = new Dictionary<string, string>();

                string password = "123456";
                string username = "fitcardTeste";
                string urlBase = "http://localhost:58071/";
                string urlToken = "api/token";

                parametros.Add("password", password);
                parametros.Add("username", username);
                parametros.Add("grant_type", "client_credentials");

                FormUrlEncodedContent content = new FormUrlEncodedContent(parametros);
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                System.Text.Encoding.ASCII.GetBytes(username + ":" + password)));
                HttpResponseMessage response = await client.PostAsync(urlToken, content);
                response.EnsureSuccessStatusCode();
                dynamic returnValue = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                dadosToken = DadosToken(returnValue);

                return dadosToken;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Recebe um objeto dinâmico convertendo-o em um objeto do tipo BuscaToken.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private BuscaToken DadosToken(dynamic response)
        {
            var dadosToken = new BuscaToken()
            {
                Access_token = response.access_token,
                Expires_in = response.expires_in,
                Token_type = response.token_type,
                Scope = response.scope
            };

            return dadosToken;
        }
    }
}

