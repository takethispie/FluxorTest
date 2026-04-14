using Produit.Presentation.Client.Store.UserAccount;

namespace Produit.Presentation.Client.Services;

public class FakeAccountDatabase
{
    private readonly List<UserAccountModel> _accounts = [];
    private readonly List<UserAccountModel> _draftAccounts = [];

    public List<UserAccountModel> GetAll() => [.._accounts, .._draftAccounts];

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
    
    public void UpsertDraft(UserAccountModel account)
    {
        if(account.Id == Guid.Empty)
        {
            account.Id = Guid.NewGuid();
            _draftAccounts.Add(account);
            return;
        }
        var idx = _draftAccounts.FindIndex(a => a.Id == account.Id);
        if (idx >= 0) _draftAccounts[idx] = account;
    }
    
    public void DeleteDraft(Guid  accountId) => _draftAccounts.RemoveAll(a => a.Id == accountId);

    public void Delete(Guid id) => _accounts.RemoveAll(a => a.Id == id);
}
