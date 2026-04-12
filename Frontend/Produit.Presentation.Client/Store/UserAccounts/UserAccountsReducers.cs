using Fluxor;

namespace Produit.Presentation.Client.Store.UserAccounts;

public static class UserAccountsReducers
{
    [ReducerMethod(typeof(FetchAccountsAction))]
    public static UserAccountsState OnFetch(UserAccountsState state) =>
        state with { IsLoading = true, Accounts = state.Accounts, Error = "" };

    [ReducerMethod]
    public static UserAccountsState OnFetchSuccess(UserAccountsState state, FetchAccountsSuccessAction a) =>
        state with { IsLoading = false, Accounts = a.Accounts, Error = "" };

    [ReducerMethod]
    public static UserAccountsState OnFetchFailure(UserAccountsState state, FetchAccountsFailureAction a) =>
        state with { IsLoading = false, Error = a.Error };
    [ReducerMethod]
    public static UserAccountsState OnDelete(UserAccountsState state, DeleteAccountAction a) =>
        state with { Accounts = [.. state.Accounts.Where(x => x.Id != a.Id)], Error = "" };
}
