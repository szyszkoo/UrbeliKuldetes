using RestSharp;
using UrbeliKuldetes.CreatingPayload;
using UrbeliKuldetes.Models;
using UrbeliKuldetes.CreatingRequests;
using System.Net;
using System;
using System.Windows;

namespace UrbeliKuldetes.Commnication
{
    class CommandsExecutor
    {
        private static string Login = "agata.szysz@gmail.com.google";
        private static string Token = "40FEBC05C9F74D4F53503794F1368B6A";
        private static Commands restart = Commands.Restart;

        public Result Execute ( string endpoint, Commands command, Parameters parameter, string value )
        {
            // Use SecurityProtocolType.T1sl2 if needed for compatibility reasons
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var payload = new PayloadCreator ( command, parameter, value, Login, Token ).ToJson ( );
            var client = new RestClient ( endpoint );
            var request = new RestRequest ( );
            request = RequestCreator.CreatePOSTRequest ( payload );
            IRestResponse response = client.Execute ( request );
            if ( response.StatusCode == HttpStatusCode.OK )
            {
                //var describeClient = new DescribeExecutor ( ); ????????????????????????
                var result = DescribeExecutor.Describe ( Login, Token );
                return result;
            }
            else
            {
                MessageBox.Show ( response.ErrorMessage );
                return null;
            }
        }

        public Result RestartSimulation (string endpoint)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var payload = new PayloadCreator ( restart, Login, Token ).ToJson ( );
            var client = new RestClient ( endpoint );
            var request = new RestRequest ( );
            request = RequestCreator.CreatePOSTRequest ( payload );
            IRestResponse response = client.Execute ( request );
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //var describeClient = new DescribeExecutor ( ); ????????????????????????????
                var result = DescribeExecutor.Describe ( Login, Token );
                return result;
            }
            else
            {
                MessageBox.Show ( response.ErrorMessage );
                return null;
            }

        }

    }
}
