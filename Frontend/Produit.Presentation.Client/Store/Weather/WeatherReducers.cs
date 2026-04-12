using Fluxor;

namespace Produit.Presentation.Client.Store.Weather;

public static class WeatherReducers
{
    [ReducerMethod]
    public static WeatherState OnLoadWeather(WeatherState state, LoadWeatherAction _) =>
        state with { IsLoading = true, ErrorMessage = null, Forecasts = state.Forecasts };

    [ReducerMethod]
    public static WeatherState OnLoadWeatherSuccess(WeatherState state, LoadWeatherSuccessAction action) =>
        state with { IsLoading = false, ErrorMessage = null, Forecasts = action.Forecasts };

    [ReducerMethod]
    public static WeatherState OnLoadWeatherFailure(WeatherState state, LoadWeatherFailureAction action) =>
        state with { IsLoading = false, ErrorMessage = action.ErrorMessage, Forecasts = null };
}
