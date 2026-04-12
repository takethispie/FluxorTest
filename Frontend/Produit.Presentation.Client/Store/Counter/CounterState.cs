using Fluxor;

namespace Produit.Presentation.Client.Store.Counter;

[FeatureState]
public record CounterState
{
    public int Count { get; init; } = 0;
    public int IncrementAmount { get; init; } = 1;

    public CounterState() { }
}
