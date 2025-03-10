using System.Text;
using System.Net.Http.Headers;
using CarbonNow.Types;
using System.Text.Json;
using CarbonNow.Types.Flight;
using System.Text.Json.Serialization;

namespace CarbonNow {
    public class Program {

        public static async Task Main() {

            // Caso queira testar algum, só descomentar e rodar.
            // Objeto está sendo instanciado dentro da função, caso queira trocar alguma informação.

            var options = new JsonSerializerOptions { WriteIndented = true };

            Console.WriteLine($"Electricity: \n{JsonSerializer.Serialize(await CalcElectricity(), options)} \n");
            Console.WriteLine($"Flight: \n{JsonSerializer.Serialize(await CalcFlight(), options)} \n");
            Console.WriteLine($"Shipping: {JsonSerializer.Serialize(await CalcShipping(), options)} \n");
            Console.WriteLine($"Vehicle: {JsonSerializer.Serialize(await CalcVehicle(), options)} \n");
            Console.WriteLine($"Fuel Combustion: {JsonSerializer.Serialize(await CalcFuelCombustion(), options)} \n");
        }

        private static async Task<Estimate.ApiResponse<Electricity>> CalcElectricity() {
            Electricity electricity = new() {
                electricity_unit = "mhw",
                electricity_value = 42.0m,
                state = "fl",
                country = "us"
            };
            return await ConsultaAPI.CalcCO2(electricity);
        }

        private static async Task<Estimate.ApiResponse<Flight>> CalcFlight() {
            Flight flight = new() {
                passengers = 2,
                legs = new[] {
                    new Legs { departure_airport = "SFO", destination_airport = "YYZ", cabin_class = "economy"},
                    new Legs { departure_airport = "YYZ", destination_airport = "SFO", cabin_class = "economy"}
                },
                distance_unit = "km"
            };
            return await ConsultaAPI.CalcCO2(flight);
        }

        private static async Task<Estimate.ApiResponse<Shipping>> CalcShipping() {
            Shipping shipping = new() {
                weight_unit = "g",
                weight_value = 200.0m,
                distance_unit = "km",
                distance_value = 2000.0m,
                transport_method = "truck"
            };
            return await ConsultaAPI.CalcCO2(shipping);
        }

        private static async Task<Estimate.ApiResponse<Vehicle>> CalcVehicle() {
            Vehicle vehicle = new() {
                distance_unit = "mi",
                distance_value = 100.0m,
                vehicle_model_id = "7268a9b7-17e8-4c8d-acca-57059252afe9"
            };
            return await ConsultaAPI.CalcCO2(vehicle);
        }

        private static async Task<Estimate.ApiResponse<FuelCombustion>> CalcFuelCombustion() {
            FuelCombustion fuelCombustion = new() {
                fuel_source_type = "dfo",
                fuel_source_unit = "btu",
                fuel_source_value = 2
            };
           return await ConsultaAPI.CalcCO2(fuelCombustion);
        }
    }
}