using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CommunicationApp.Models;

namespace CommunicationApp.CreatingPayload
{
    class PayloadCreator
    {
        public string Command { get; }
        public string Login { get; }
        public string Token { get; }
        public string Parameter { get; }
        public decimal Value { get; }

        //creating payload with no parameter
        public PayloadCreator(Commands command, string login, string token)
        {
            Command = command.ToString();
            Login = login;
            Token = token;
        }
        //creating payload with one parameter
        public PayloadCreator(Commands command, string parameter, string login, string token)
        {
            Command = command.ToString();
            Login = login;
            Token = token;
            Parameter = parameter;
        }
        //creating payload with a parameter and a value
        public PayloadCreator(Commands command, string parameter, decimal value, string login, string token )
        {
            Command = command.ToString();
            Login = login;
            Token = token;
            Parameter = parameter;
            Value = value;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
