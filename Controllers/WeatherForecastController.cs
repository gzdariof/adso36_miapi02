using Microsoft.AspNetCore.Mvc;

namespace MiApi02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ClimasCantidad")]
        public IEnumerable<WeatherForecast> GetClimasCantidad(int cantidad)
        {
            return Enumerable.Range(1, cantidad).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        /*
Clima	Rango °C	Rango °F	Sensación aproximada
🧊 Freezing	≤ 0 °C	≤ 32 °F	Helado
🥶 Bracing	1–7 °C	33–45 °F	Muy frío
❄️ Chilly	8–12 °C	46–54 °F	Frío
🌬️ Cool	13–17 °C	55–63 °F	Fresco
🙂 Mild	18–22 °C	64–72 °F	Templado
🌤️ Warm	23–27 °C	73–81 °F	Cálido
🌴 Balmy	28–31 °C	82–88 °F	Cálido y agradable
☀️ Hot	32–35 °C	90–95 °F	Caluroso
🥵 Sweltering	36–39 °C	97–102 °F	Sofocante
🔥 Scorching	≥ 40 °C	≥ 104 °F	Extremadamente caluroso         
         */

        private string GetSummary(int temperatureC)
        {
            if (temperatureC < 0)
                return Summaries[0]; // Freezing
            else if (temperatureC < 7)
                return Summaries[1]; // Bracing
            else if (temperatureC < 12)
                return Summaries[2]; // Chilly
            else if (temperatureC < 17)
                return Summaries[3]; // Cool
            else if (temperatureC < 22)
                return Summaries[4]; // Mild
            else if (temperatureC < 27)
                return Summaries[5]; // Warm
            else if (temperatureC < 31)
                return Summaries[6]; // Balmy
            else if (temperatureC < 35)
                return Summaries[7]; // Hot
            else if (temperatureC < 39)
                return Summaries[8]; // Sweltering
            else
                return Summaries[9]; // Scorching (>= 39)
        }

        [HttpGet("ClimasCustom")]
        public IEnumerable<WeatherForecast> GetClimasCustom(int cantidad)
        {
            int tempC = 0;
            var lista = Enumerable.Range(1, cantidad).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = tempC = Random.Shared.Next(-20, 55),
                Summary = this.GetSummary(tempC)
            })
            .ToArray();
            return lista;
        }
    }
}
