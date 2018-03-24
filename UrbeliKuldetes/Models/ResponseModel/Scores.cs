using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationApp.Models.ResponseModel
{
    public struct Scores
    {
        public decimal SurvivorsScore { get; set; }
        public decimal ScienceScore { get; set; }
        public decimal CrewMalus { get; set; }
        public decimal KnowledgeScore { get; set; }
        public decimal EventScore { get; set; }
        public decimal TotalScore { get; set; }
    }
}
