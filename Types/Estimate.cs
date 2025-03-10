using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonNow.Types {
    public class Estimate {

        public class ApiResponse<TModel> {
            public ApiData<TModel> data { get; set; }
        }

        public class ApiData<TModel> {
            public string id { get; set; }
            public string type { get; set; }
            public TModel attributes { get; set; }
        }
    }
}