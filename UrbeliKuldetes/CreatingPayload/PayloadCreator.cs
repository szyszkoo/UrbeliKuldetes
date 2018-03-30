using Newtonsoft.Json;
using UrbeliKuldetes.Models;

namespace UrbeliKuldetes.CreatingPayload
{
    class PayloadCreator
    {
        public string Command { get; }
        public string Login { get; }
        public string Token { get; }
        public string Parameter { get; }
        public string Value { get; }

        //creating payload with no parameter
        public PayloadCreator(Commands command, string login, string token)
        {
            Command = command.ToString();
            Login = login;
            Token = token;
        }
        //creating payload with one parameter
        public PayloadCreator(Commands command, Parameters parameter, string login, string token)
        {
            Command = command.ToString();
            Login = login;
            Token = token;
            Parameter = parameter.ToString();
        }

        //TODO : how to send Produce Supplies ????? (decimal Value)

        ////creating payload with a parameter and a decimal value
        //public PayloadCreator(Commands command, Parameters parameter, decimal value, string login, string token )
        //{
        //    Command = command.ToString();
        //    Login = login;
        //    Token = token;
        //    Parameter = parameter.ToString();
        //    Value = value;
        //}
        //payload with a parameter and enum  value (Order Command)
        public PayloadCreator ( Commands command, Parameters parameter, string value, string login, string token )
        {
            Command = command.ToString ( );
            Login = login;
            Token = token;
            Parameter = parameter.ToString ( );
            Value = value;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
