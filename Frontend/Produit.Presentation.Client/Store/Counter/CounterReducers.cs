using Fluxor;

namespace Produit.Presentation.Client.Store.Counter;

public static class CounterReducers
{
    [ReducerMethod]
    public static CounterState OnIncrement(CounterState state, IncrementCounterAction action) =>
        state with { Count = state.Count + action.Amount, IncrementAmount = state.IncrementAmount };

    [ReducerMethod]
    public static CounterState OnDecrement(CounterState state, DecrementCounterAction action) =>
        state with { Count = state.Count - action.Amount, IncrementAmount = state.IncrementAmount };

    [ReducerMethod]
    public static CounterState OnReset(CounterState state, ResetCounterAction action) =>
        state with { Count = 0, IncrementAmount = state.IncrementAmount };

    [ReducerMethod]
    public static CounterState OnSetIncrementAmount(CounterState state, SetIncrementAmountAction action) =>
        state with { Count = state.Count, IncrementAmount = action.Amount };
}
