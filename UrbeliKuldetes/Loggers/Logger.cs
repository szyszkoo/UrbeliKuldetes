using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using UrbeliKuldetes.Models;
using System.IO;

namespace UrbeliKuldetes.Loggers
{
    class Logger
    {
        private static List<string> listOfLogsToWrite = new List<string> ( );
        public static void PrepareDataToWrite ( Result resultToWrite, string commandUsed, string parameterUsed, string valueUsed )
        {
            StringBuilder logFromOneTurn = new StringBuilder ( );
            logFromOneTurn.AppendLine ( "======================================================================================" );
            logFromOneTurn.AppendLine ( "N E W    T U R N " );
            logFromOneTurn.AppendLine ( "======================================================================================" );
            if(commandUsed!= null)
            {
                logFromOneTurn.Append ( "Command used: " );
                logFromOneTurn.AppendLine ( commandUsed );
            }
            if ( parameterUsed != null )
            {
                logFromOneTurn.Append ( "Parameter used: " );
                logFromOneTurn.AppendLine ( parameterUsed );
            }
            if ( valueUsed != null )
            {
                logFromOneTurn.Append ( "Value used: " );
                logFromOneTurn.AppendLine ( valueUsed );
            }
            logFromOneTurn.AppendLine ( );
            resultToWrite.Events = null;
            var tempResultAsStr = JsonConvert.SerializeObject ( resultToWrite, Formatting.Indented );
            tempResultAsStr = tempResultAsStr.Replace ( @"""Events"": null,", "" );
            logFromOneTurn.AppendLine ( tempResultAsStr  );            
            listOfLogsToWrite.Add ( logFromOneTurn.ToString ( ) );
            
        }

        public static void WriteToFile ()
        {

            StreamWriter logsFile = new StreamWriter ( @".\Logs.txt" );
            foreach ( var log in listOfLogsToWrite )
            {
                logsFile.WriteLine ( log );
            }
            logsFile.Close ( );

        }     

    }
}
