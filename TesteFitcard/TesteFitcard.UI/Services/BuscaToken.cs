using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFitcard.UI.RestClient
{
    public class BuscaToken
    {
        public string Access_token { get; set; }
        public string Expires_in { get; set; }
        public string Token_type { get; set; }
        public string Scope { get; set; }
    }
}
