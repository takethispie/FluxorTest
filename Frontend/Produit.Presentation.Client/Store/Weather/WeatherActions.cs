using Produit.Presentation.Client.Models.Weather;

namespace Produit.Presentation.Client.Store.Weather;

public record LoadWeatherAction();

public record LoadWeatherSuccessAction(WeatherForecast[] Forecasts);

public record LoadWeatherFailureAction(string ErrorMessage);
