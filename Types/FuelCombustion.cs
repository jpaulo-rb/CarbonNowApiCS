using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonNow.Types {
    public class FuelCombustion {
        public string type { get; } = "fuel_combustion";
        public string fuel_source_type { get; set; } // Opções: https://faint-class-d56.notion.site/Carbon-Interface-Fuel-Sources-0166b59ec1514984895cc7dd35836392
        public string fuel_source_unit { get; set; } // Opções: https://faint-class-d56.notion.site/Carbon-Interface-Fuel-Sources-0166b59ec1514984895cc7dd35836392
        public decimal fuel_source_value { get; set; }


        // Resposta da API
        public string estimated_at { get; set; }
        public decimal carbon_g { get; set; }
        public decimal carbon_lb { get; set; }
        public decimal carbon_kg { get; set; }
        public decimal carbon_mt { get; set; }
    }
}
