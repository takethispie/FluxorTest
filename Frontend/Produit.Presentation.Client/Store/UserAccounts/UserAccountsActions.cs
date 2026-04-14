using Produit.Presentation.Client.Models;

namespace Produit.Presentation.Client.Store.UserAccounts;

public record FetchAccountsAction();
public record FetchAccountsSuccessAction(List<UserAccountModel> Accounts);
public record FetchAccountsFailureAction(string Error);
public record DeleteAccountAction(Guid Id);
