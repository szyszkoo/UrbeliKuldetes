using RestSharp;
using UrbeliKuldetes.CreatingPayload;
using UrbeliKuldetes.Models;
using UrbeliKuldetes.CreatingRequests;
using System.Net;
using System;

namespace UrbeliKuldetes.Commnication
{
    class CommandsExcecutor
    {
        private static string Login = "agata.szysz@gmail.com.google";
        private static string Token = "40FEBC05C9F74D4F53503794F1368B6A";
        private static Commands restart = Commands.Restart;
        
        public Result Execute(string endpoint, Commands command, Parameters parameter)
        {
            var payload = new PayloadCreator (command, parameter, Login, Token).ToJson( );
            var client = new RestClient (endpoint);
            var request = new RestRequest ();
            request = RequestCreator.CreatePOSTRequest (payload);
            IRestResponse response = client.Execute (request);
            if ( response.StatusCode == HttpStatusCode.OK )
            {
                var describeClient = new DescribeExcecutor ( );
                var result = DescribeExcecutor.Execute ( Login, Token );
                return result;
            }
            else return null;
        }
        public void RestartSimulation(string endpoint)
        {
            var payload = new PayloadCreator ( restart, Login, Token ).ToJson ( );
            var client = new RestClient ( endpoint );
            var request = new RestRequest ( );
            request = RequestCreator.CreatePOSTRequest ( payload );
            IRestResponse response = client.Execute ( request );
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var describeClient = new DescribeExcecutor ( );
                var result = DescribeExcecutor.Execute ( Login, Token );
            }

        }

    }
}
