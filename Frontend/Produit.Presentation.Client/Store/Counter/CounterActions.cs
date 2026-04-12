namespace Produit.Presentation.Client.Store.Counter;

public record IncrementCounterAction(int Amount);

public record DecrementCounterAction(int Amount);

public record ResetCounterAction();

public record SetIncrementAmountAction(int Amount);
