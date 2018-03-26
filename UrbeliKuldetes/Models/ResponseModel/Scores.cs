using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbeliKuldetes.Models.ResponseModel
{
    public struct Scores
    {
        public decimal SurvivorsScore { get; set; }
        public decimal ScienceScore { get; set; }
        public decimal CrewMalus { get; set; }
        public decimal KnowledgeScore { get; set; }
        public decimal EventScore { get; set; }
        public decimal TotalScore { get; set; }

        public string GetScoresNames ( )
        {
            string scoresNamesAsString = "";
            var properties = TypeDescriptor.GetProperties ( this.GetType ( ) );
            for ( int i = 0; i < properties.Count; i++ )
            {
                scoresNamesAsString = scoresNamesAsString + properties[i].Name + "\n";
            }
            return scoresNamesAsString;
        }
    }
}
