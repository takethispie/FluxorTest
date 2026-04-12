using Fluxor;

namespace Produit.Presentation.Client.Store.Weather;

[FeatureState]
public record WeatherState
{
    public bool IsLoading { get; init; } = false;
    public WeatherForecast[]? Forecasts { get; init; } = [];
    public string? ErrorMessage { get; init; } = null;

    // Required by Fluxor for initial state construction
    public WeatherState() {}
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
