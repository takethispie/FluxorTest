using Fluxor;
using System.Net.Http.Json;
using Produit.Presentation.Client.Models.Weather;

namespace Produit.Presentation.Client.Store.Weather;

public class WeatherEffects(HttpClient http)
{
    [EffectMethod]
    public async Task HandleLoadWeather(LoadWeatherAction action, IDispatcher dispatcher)
    {
        try
        {
            var forecasts = await http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
            dispatcher.Dispatch(new LoadWeatherSuccessAction(forecasts ?? []));
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new LoadWeatherFailureAction(ex.Message));
        }
    }
}
