using Fluxor;
using Produit.Presentation.Client.Models;
using Produit.Presentation.Client.Services;

namespace Produit.Presentation.Client.Store.UserAccount;

public class UserAccountEffects(FakeAccountDatabase db)
{
    [EffectMethod]
    public Task HandleSave(SaveAccountAction action, IDispatcher _)
    {
        return Upsert(action.Account);
    }

    [EffectMethod]
    public Task HandleFinalize(FinalizeAccountAction action, IDispatcher _) => Upsert(action.Account);

    private Task Upsert(UserAccountModel account)
    {
        db.Upsert(account);
        return Task.CompletedTask;
    }
}
