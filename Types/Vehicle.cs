using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonNow.Types {
    public class Vehicle {
        public string type { get; } = "vehicle";
        public string distance_unit { get; set; } // Opções: miles (mi) or kilometers (km)
        public decimal distance_value { get; set; }
        public string vehicle_model_id { get; set; }


        // Resposta da API
        public string vehicle_make { get; set; }
        public string vehicle_model { get; set; }
        public int vehicle_year { get; set; }
        public string estimated_at { get; set; }
        public decimal carbon_g { get; set; }
        public decimal carbon_lb { get; set; }
        public decimal carbon_kg { get; set; }
        public decimal carbon_mt { get; set; }

    }

    public class VehicleModel {
        public VehicleData data { get; set; }
    }

    public class VehicleData {
        public string id { get; set; }
        public string type { get; } = "vehicle_make";
        public VehicleAttributes attributes { get; set; }
    }

    public class VehicleAttributes {
        public string name { get; set; }
        public int number_of_models { get; set; }
    }
}
