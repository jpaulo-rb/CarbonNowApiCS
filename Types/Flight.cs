using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonNow.Types.Flight {
    public class Flight {

        public string type { get; } = "flight";
        public int passengers { get; set; }
        public Legs[] legs { get; set; } // Dois objetos, um de ida e o outro de volta
        public string distance_unit { get; set; } = "km"; // Opções: km, mi


        // Resposta da API
        public string estimated_at { get; set; }
        public decimal carbon_g { get; set; }
        public decimal carbon_lb { get; set; }
        public decimal carbon_kg { get; set; }
        public decimal carbon_mt { get; set; }
    }

    public class Legs {
        public string departure_airport { get; set; }
        public string destination_airport { get; set; }
        public string cabin_class { get; set; } = "economy";
    }
}
