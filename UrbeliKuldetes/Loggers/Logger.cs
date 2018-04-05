using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using UrbeliKuldetes.Models;

namespace UrbeliKuldetes.Loggers
{
    class Logger
    {
        private List<string> listOfLogsToWrite = new List<string> ( );
        public void PrepareDataToWrite ( Result resultToWrite, string commandUsed, string parameterUsed, string valueUsed )
        {
            StringBuilder logFromOneTurn = new StringBuilder ( );
            logFromOneTurn.AppendLine ( "======================================================================================" );
            logFromOneTurn.AppendLine ( "N E W    T U R N " );
            logFromOneTurn.AppendLine ( "======================================================================================" );
            logFromOneTurn.Append ( "Command used: " );
            logFromOneTurn.AppendLine ( commandUsed );
            logFromOneTurn.Append ( "Parameter used: " );
            logFromOneTurn.AppendLine ( parameterUsed );
            if ( valueUsed != null )
            {
                logFromOneTurn.Append ( "Value used: " );
                logFromOneTurn.AppendLine ( valueUsed );
            }
            logFromOneTurn.AppendLine ( );
            logFromOneTurn.AppendLine ( JsonConvert.SerializeObject ( resultToWrite ) );

            listOfLogsToWrite.Add ( logFromOneTurn.ToString ( ) );
            
        }

        public void WriteToFile ()
        {
            System.IO.StreamWriter logsFile = new System.IO.StreamWriter ( @".\Logs.txt");
            foreach (var log in listOfLogsToWrite)
            {
                logsFile.WriteLine ( log );
            }

            logsFile.Close ( );
        }
        //private void WriteResultToLog(Result resultToWriteToLog, List<string> listOfLogs)
        //{

        //}
        


    }
}
