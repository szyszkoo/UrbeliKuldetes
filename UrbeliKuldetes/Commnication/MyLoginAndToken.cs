using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbeliKuldetes.Commnication
{
    class MyLoginAndToken
    {
        private static string Login { get; set; }
        private static string Token { get; set; }
        public MyLoginAndToken()
        {
            Login = "agata.szysz@gmail.com.google";
            Token = "40FEBC05C9F74D4F53503794F1368B6A";
        }
        public string getLogin()
        {
            return Login;
        }
        public string getToken()
        {
            return Token;
        }
    }
}
