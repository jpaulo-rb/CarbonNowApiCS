using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonNow.Types {
    public class Shipping {
        public string type { get; } = "shipping";
        public string weight_unit { get; set; } // Opções = grams (g), pounds (lb), kilograms (kg) or tonnes (mt)
        public decimal weight_value { get; set; }
        public string distance_unit { get; set; } // Opções = miles (mi) or kilometers (km)
        public decimal distance_value { get; set; }
        public string transport_method { get; set; } // Opções = ship, train, truck and plane


        // Resposta da API
        public string estimated_at { get; set; }
        public decimal carbon_g { get; set; }
        public decimal carbon_lb { get; set; }
        public decimal carbon_kg { get; set; }
        public decimal carbon_mt { get; set; }
    }
}
