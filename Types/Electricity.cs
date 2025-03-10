using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonNow.Types {
    public class Electricity {

        // Ao consumir a API conseguimos obter a emissão de carbono de acordo com a eletricidade gastada.
        // Utilizar eletricidade em si, não gera CO2, porém a forma como a energia é produzida, pode gastar
        // Exemplo disso são energia produzidas de fontes como carvão, gás e petróleo

        public string type { get; } = "electricity";

        public string electricity_unit { get; set; } = "kwh"; // Unidade de medida para energia, opções: Kwh ou Mwh

        // kWh = (Potência(Watts) * Tempo(Horas)) / 1000
        // mWh = (Potência(Watts) * Tempo(Horas)

        public decimal electricity_value { get; set; } // Quantidade de energia consumida ou gerada de acordo com a medida informada acima

        public string country { get; set; } = "pt"; // País utilizado para fazer a estimativa de emissão de CO2.
                                                    // Países com suporte: https://faint-class-d56.notion.site/4b4f41db73254b4b915ba01d55eba7e7?v=4ad0efe7763540ab801fadd9f3bf1ce0

        public string? state { get; set; } = ""; // Estado utilizado para ter uma precisão maior no cálculo de emissão.
                                                 // Somente estados da Estados Unidos e Canadá, e deve ser informado a sigla de 2 letras do ISO code


        // Resposta da API
        public string estimated_at { get; set; }
        public decimal carbon_g { get; set; }
        public decimal carbon_lb { get; set; }
        public decimal carbon_kg { get; set; }
        public decimal carbon_mt { get; set; }
    }
}
