using CommunicationApp.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommunicationApp.Models
{
    class Result
    {
        public decimal Turn { get; set; }
        public Params Parameters { get; set; }
        public IList<string> Events { get; set; }
        public string Location { get; set; }
        public IList<string> LastTurnEvents { get; set; }
        public IList<string> Equipments { get; set; }
        public IList<string> LogBook { get; set; }
        public Scores AllScores { get; set; }
        public bool IsTerminated { get; set; }
    }
}

