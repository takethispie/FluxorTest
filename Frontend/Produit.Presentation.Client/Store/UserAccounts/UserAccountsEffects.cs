using Fluxor;
using Produit.Presentation.Client.Services;

namespace Produit.Presentation.Client.Store.UserAccounts;

public class UserAccountsEffects(FakeAccountDatabase db)
{
    [EffectMethod(typeof(FetchAccountsAction))]
    public async Task HandleFetch(IDispatcher dispatcher)
    {
        await Task.Delay(300);
        dispatcher.Dispatch(new FetchAccountsSuccessAction(db.GetAll()));
    }

    [EffectMethod]
    public Task HandleDelete(DeleteAccountAction action, IDispatcher dispatcher)
    {
        db.Delete(action.Id);
        return Task.CompletedTask;
    }
}
