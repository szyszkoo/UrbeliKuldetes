using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UrbeliKuldetes.CreatingRequests;
using UrbeliKuldetes.Models;

namespace UrbeliKuldetes.Commnication
{
    class DescribeExecutor
    {
        public static Result Describe(string login, string token)
        {
            // Use SecurityProtocolType.T1sl2 if needed for compatibility reasons
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string endpoint = "https://simulation.future-processing.pl/describe?login=" + login + "&token=" + token;
            var describeClient = new RestClient (endpoint);
            var describeRequest = RequestCreator.CreateGETRequest();
            IRestResponse describeResponse = describeClient.Execute ( describeRequest );
            if ( describeResponse.StatusCode == HttpStatusCode.OK )
            {
                   return JsonConvert.DeserializeObject<Result> ( describeResponse.Content ); 

            }
            else
            {
                return null;
            }

        }
    }
}
