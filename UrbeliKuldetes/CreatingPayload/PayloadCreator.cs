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

        public PayloadCreator(Commands command, string login, string token)
        {
            Command = command.ToString();
            Login = login;
            Token = token;
        }
        public PayloadCreator(Commands command, Parameters parameter, string login, string token)
        {
            Command = command.ToString();
            Login = login;
            Token = token;
            Parameter = parameter.ToString();
        }
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
