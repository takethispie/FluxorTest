using Moq;
using Fluxor;
using Produit.Presentation.Client.Models;
using Produit.Presentation.Client.Services;
using Produit.Presentation.Client.Store.UserAccount;

namespace Produit.Presentation.Client.Tests.Store.UserAccount;

public class UserAccountEffectsTests
{
    private readonly FakeAccountDatabase _db = new();
    private readonly Mock<IDispatcher> _dispatcher = new();

    private UserAccountEffects CreateEffects() => new(_db);

    // ── HandleSave ───────────────────────────────────────────────────────────

    [Fact]
    public async Task HandleSave_UpsertsAccount()
    {
        var account = new UserAccountModel { Id = Guid.Empty };
        var effects = CreateEffects();

        await effects.HandleSave(new SaveAccountAction(account), _dispatcher.Object);

        Assert.Single(_db.GetAll());
    }

    // ── HandleSaveUserInfo ───────────────────────────────────────────────────

    [Fact]
    public async Task HandleSaveUserInfo_UpsertsAccountFromState()
    {
        var state = new UserAccountState
        {
            Id = Guid.Empty,
            UserInfo = new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" },
            Step1Valid = true,
            Step2Valid = true,
            Step3Valid = true
        };
        var effects = CreateEffects();

        await effects.HandleSaveUserInfo(new SaveUserInfoAction(state), _dispatcher.Object);

        var all = _db.GetAll();
        Assert.Single(all);
        Assert.Equal("Alice", all[0].UserInfo.FirstName);
    }

    // ── HandleSaveHobbies ────────────────────────────────────────────────────

    [Fact]
    public async Task HandleSaveHobbies_UpsertsAccount()
    {
        var account = new UserAccountModel { Id = Guid.Empty };
        var effects = CreateEffects();

        await effects.HandleSaveHobbies(new SaveHobbiesAction(account), _dispatcher.Object);

        Assert.Single(_db.GetAll());
    }

    // ── HandleSaveVehicles ───────────────────────────────────────────────────

    [Fact]
    public async Task HandleSaveVehicles_UpsertsAccount()
    {
        var account = new UserAccountModel { Id = Guid.Empty };
        var effects = CreateEffects();

        await effects.HandleSaveVehicles(new SaveVehiclesAction(account), _dispatcher.Object);

        Assert.Single(_db.GetAll());
    }

    // ── HandleFinalize ───────────────────────────────────────────────────────

    [Fact]
    public async Task HandleFinalize_UpsertsAccount()
    {
        var account = new UserAccountModel { Id = Guid.Empty };
        var effects = CreateEffects();

        await effects.HandleFinalize(new FinalizeAccountAction(account), _dispatcher.Object);

        Assert.Single(_db.GetAll());
    }

    // ── Upsert idempotency ───────────────────────────────────────────────────

    [Fact]
    public async Task HandleSave_CalledTwiceWithSameId_UpdatesInPlace()
    {
        // First insert via Guid.Empty (db assigns a new id)
        var account = new UserAccountModel { Id = Guid.Empty, UserInfo = new UserInfo { FirstName = "Alice" } };
        var effects = CreateEffects();

        await effects.HandleSave(new SaveAccountAction(account), _dispatcher.Object);

        // Retrieve the assigned id
        var assignedId = _db.GetAll()[0].Id;

        var updated = new UserAccountModel { Id = assignedId, UserInfo = new UserInfo { FirstName = "Bob" } };
        await effects.HandleSave(new SaveAccountAction(updated), _dispatcher.Object);

        var all = _db.GetAll();
        Assert.Single(all);
        Assert.Equal("Bob", all[0].UserInfo.FirstName);
    }
}
