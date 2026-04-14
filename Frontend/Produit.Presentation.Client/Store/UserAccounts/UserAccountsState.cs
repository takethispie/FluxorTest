using Fluxor;
using Produit.Presentation.Client.Models;

namespace Produit.Presentation.Client.Store.UserAccounts;

[FeatureState]
public record UserAccountsState
{
    public bool IsLoading { get; init; } = false;
    public List<UserAccountModel> Accounts { get; init; } = [];
    public string Error { get; init; } = "";

    public UserAccountsState() { }
}
