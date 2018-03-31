using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbeliKuldetes.Models.ResponseModel
{
    public class Params
    {
        public decimal SavedScience { get; set; }
        public decimal SavedSurvivors { get; set; }
        public decimal Knowledge { get; set; }
        public decimal CrewDeaths { get; set; }
        public decimal SurvivorDeaths { get; set; }
        public decimal ChaarrHatred { get; set; }
        [JsonProperty ( "PołudnicaMatter" )]
        public decimal PoludnicaMatter { get; set; }
        [JsonProperty ( "PołudnicaEnergy" )]
        public decimal PoludnicaEnergy { get; set; }
        public decimal ExpeditionMatter { get; set; }
        public decimal ExpeditionEnergy { get; set; }


        public string GetParamsNames ( )
        {
            string paramsNamesAsString="";
            var properties = TypeDescriptor.GetProperties ( this.GetType ( ) );
            for ( int i = 0; i < properties.Count; i++ )
            {
                paramsNamesAsString = paramsNamesAsString + properties[i].Name + "\n";
            }
            return paramsNamesAsString;
        }
    }
}
