using Fluxor;
using Produit.Presentation.Client.Services;

namespace Produit.Presentation.Client.Store.UserAccount;

public class UserAccountEffects(FakeAccountDatabase db)
{
    [EffectMethod]
    public Task HandleSave(SaveAccountAction action, IDispatcher _)
    {
        db.Upsert(action.Account);
        return Task.CompletedTask;
    }

    [EffectMethod]
    public Task HandleFinalize(FinalizeAccountAction action, IDispatcher _)
    {
        db.Upsert(action.Account);
        return Task.CompletedTask;
    }
}
