using System.Collections.Generic;
using System.Net;

namespace TesteFitcard.UI.RestClient
{
    /// <summary>
    /// Classe que representa o retorno de uma requisição.
    /// </summary>
    public class Response
    {
        //public object Data { get; set; }        
        //public HttpStatusCode StatusCode { get; set; }
     
            public int key { get; set; }
            public List<object> value { get; set; }
        
    }
}
