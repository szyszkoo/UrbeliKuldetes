using RestSharp;
using UrbeliKuldetes.CreatingPayload;
using UrbeliKuldetes.Models;
using UrbeliKuldetes.CreatingRequests;
using System.Net;
using System;
using System.Windows;
using UrbeliKuldetes.Loggers;

namespace UrbeliKuldetes.Commnication
{
    class CommandsExecutor
    {
        private static Commands restart = Commands.Restart;
        private static string Login { get; set; }
        private static string Token { get; set; }
        private static string SimulationOrChaarr { get; set; }
        public CommandsExecutor(string _login, string _token, string _simOrChaarr)
        {
            Login = _login;
            Token = _token;
            SimulationOrChaarr = _simOrChaarr;
        }
        public Result Execute ( Commands command, Parameters parameter, string value )
        {
            // Use SecurityProtocolType.T1sl2 if needed for compatibility reasons
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var payload = new PayloadCreator ( command, parameter, value, Login, Token ).ToJson ( );
            string endpoint = CreateEndpoint ( SimulationOrChaarr );
            var client = new RestClient ( endpoint );
            var request = new RestRequest ( );
            request = RequestCreator.CreatePOSTRequest ( payload );
            IRestResponse response = client.Execute ( request );
            if ( response.StatusCode == HttpStatusCode.OK )
            {
                //var describeClient = new DescribeExecutor ( ); ????????????????????????
                var result = DescribeExecutor.Describe ( Login, Token , SimulationOrChaarr);
                Logger.PrepareDataToWrite ( result, command.ToString(), parameter.ToString(), value );
                if(result.IsTerminated)
                {
                    MessageBox.Show ( "GAME OVER, YOU LOST. Your simulation will be restarted now. Good luck!" );
                    RestartSimulation ( );
                }
                return result;
            }
            else
            {
                MessageBox.Show ( response.ErrorMessage + response.Content );
                return null;
            }
        }

        public Result RestartSimulation ()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Logger.WriteToFile ( );

            var payload = new PayloadCreator ( restart, Login, Token ).ToJson ( );
            string endpoint = CreateEndpoint ( SimulationOrChaarr );
            var client = new RestClient ( endpoint );
            var request = new RestRequest ( );
            request = RequestCreator.CreatePOSTRequest ( payload );
            IRestResponse response = client.Execute ( request );
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //var describeClient = new DescribeExecutor ( ); ????????????????????????????
                var result = DescribeExecutor.Describe ( Login, Token, SimulationOrChaarr );
                if ( result != null )
                {
                    return result;
                }
                else return null;
            }
            else
            {
                MessageBox.Show ( response.ErrorMessage );
                return null;
            }

        }
        private string CreateEndpoint ( string simOrChaarr )
        {
            return $"https://{simOrChaarr}.future-processing.pl/execute";
        }

    }
}
