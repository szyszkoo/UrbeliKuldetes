using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbeliKuldetes.Models.ResponseModel
{
    public struct Params
    {
        public decimal SavedScience { get; set; }
        public decimal SavedSurvivors { get; set; }
        public decimal Knowledge { get; set; }
        public decimal CrewDeaths { get; set; }
        public decimal SurvivorDeaths { get; set; }
        public decimal ChaarrHatred { get; set; }
        public decimal PoludnicaMatter { get; set; }
        public decimal PoludnicaEnergy { get; set; }
        public decimal ExpeditionMatter { get; set; }
        public decimal ExpeditionEnergy { get; set; }
    }
}
