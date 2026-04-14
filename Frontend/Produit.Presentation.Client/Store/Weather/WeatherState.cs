using Fluxor;
using Produit.Presentation.Client.Models.Weather;

namespace Produit.Presentation.Client.Store.Weather;

[FeatureState]
public record WeatherState
{
    public bool IsLoading { get; init; } = false;
    public WeatherForecast[]? Forecasts { get; init; } = [];
    public string? ErrorMessage { get; init; } = null;

    public WeatherState() {}
}
