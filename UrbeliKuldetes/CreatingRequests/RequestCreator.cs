using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace UrbeliKuldetes.CreatingRequests
{
    class RequestCreator
    {
        public static RestRequest CreatePOSTRequest(string payload)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");

            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public static RestRequest CreateGETRequest()
        {
            var request = new RestRequest(Method.GET);
            return request;
        }
    }
}
