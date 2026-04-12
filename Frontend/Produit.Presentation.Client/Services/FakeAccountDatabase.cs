using Produit.Presentation.Client.Store.UserAccount;

namespace Produit.Presentation.Client.Services;

public class FakeAccountDatabase
{
    private readonly List<UserAccountModel> _accounts = [];

    public List<UserAccountModel> GetAll() => [.._accounts];

    public void Upsert(UserAccountModel account)
    {
        if(account.Id == Guid.Empty)
        {
            account.Id = Guid.NewGuid();
            _accounts.Add(account);
            return;
        }
        var idx = _accounts.FindIndex(a => a.Id == account.Id);
        if (idx >= 0) _accounts[idx] = account;
    }

    public void Delete(Guid id) => _accounts.RemoveAll(a => a.Id == id);
}
