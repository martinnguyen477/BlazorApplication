using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApplication.Pages
{
    /// <summary>
    /// Code behind của view Razor phải đặt đúng tên. Nếu không đúng tên thì phải thêm dòng code này:
    /// @Inherits @FetchData ở bên View 
    /// </summary>
    public partial class FetchData
    {
        private WeatherForecast[] forecasts;

        /// <summary>
        /// Nếu để ở bên view thì thêm đoạn code Directive này.
        /// @Inject HttpClient Http
        /// </summary>
        [Inject] private HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }

            public int TemperatureC { get; set; }

            public string Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
