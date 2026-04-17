using Produit.Presentation.Client.Models;
using Produit.Presentation.Client.Store.UserAccount;

namespace Produit.Presentation.Client.Tests.Store.UserAccount;

public class UserAccountReducersTests
{
    private static UserAccountState EmptyState() => new();

    // ── LoadForEdit ──────────────────────────────────────────────────────────

    [Fact]
    public void LoadForEdit_SetsAllFields()
    {
        var account = new UserAccountModel
        {
            Id = Guid.NewGuid(),
            UserInfo = new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" },
            Hobbies = [new Hobby { Id = Guid.NewGuid(), Name = "Reading" }],
            Vehicles = [new Vehicle { Id = Guid.NewGuid(), Make = "Toyota", Model = "Yaris", LicensePlate = "AB-123-CD" }]
        };

        var result = UserAccountReducers.LoadForEdit(EmptyState(), new LoadAccountForEditAction(account));

        Assert.Equal(account.Id, result.Id);
        Assert.Equal(account.UserInfo, result.UserInfo);
        Assert.Equal(account.Hobbies, result.Hobbies);
        Assert.Equal(account.Vehicles, result.Vehicles);
        Assert.True(result.Step1Valid);
        Assert.True(result.Step2Valid);
        Assert.True(result.Step3Valid);
        Assert.False(result.IsSubmitted);
    }

    [Fact]
    public void LoadForEdit_NoHobbies_Step2Invalid()
    {
        var account = new UserAccountModel { Id = Guid.NewGuid(), Hobbies = [], Vehicles = [new Vehicle()] };
        var result = UserAccountReducers.LoadForEdit(EmptyState(), new LoadAccountForEditAction(account));
        Assert.False(result.Step2Valid);
    }

    [Fact]
    public void LoadForEdit_NoVehicles_Step3Invalid()
    {
        var account = new UserAccountModel { Id = Guid.NewGuid(), Hobbies = [new Hobby()], Vehicles = [] };
        var result = UserAccountReducers.LoadForEdit(EmptyState(), new LoadAccountForEditAction(account));
        Assert.False(result.Step3Valid);
    }

    // ── SaveUserInfo ─────────────────────────────────────────────────────────

    [Fact]
    public void SaveUserInfo_ReplacesStateWithNewAccountState()
    {
        var newState = new UserAccountState { Step1Valid = true };
        var result = UserAccountReducers.SaveUserInfo(EmptyState(), new SaveUserInfoAction(newState));
        Assert.Equal(newState, result);
    }

    // ── ValidateUserInfo ─────────────────────────────────────────────────────

    [Theory]
    [InlineData("Alice", "Smith", "a@b.com", true)]
    [InlineData("", "Smith", "a@b.com", false)]
    [InlineData("Alice", "", "a@b.com", false)]
    [InlineData("Alice", "Smith", "", false)]
    [InlineData("   ", "Smith", "a@b.com", false)]
    public void ValidateUserInfo_Step1Valid(string first, string last, string email, bool expected)
    {
        var result = UserAccountReducers.ValidateUserInfo(EmptyState(), new ValidateUserInfoAction(first, last, email));
        Assert.Equal(expected, result.Step1Valid);
    }

    // ── AddHobby ─────────────────────────────────────────────────────────────

    [Fact]
    public void AddHobby_AppendsHobby()
    {
        var hobby = new Hobby { Id = Guid.NewGuid(), Name = "Chess" };
        var result = UserAccountReducers.AddHobby(EmptyState(), new AddHobbyAction(hobby));
        Assert.Single(result.Hobbies);
        Assert.Equal(hobby, result.Hobbies[0]);
    }

    [Fact]
    public void AddHobby_PreservesExistingHobbies()
    {
        var existing = new Hobby { Id = Guid.NewGuid(), Name = "Chess" };
        var state = EmptyState() with { Hobbies = [existing] };
        var newHobby = new Hobby { Id = Guid.NewGuid(), Name = "Painting" };

        var result = UserAccountReducers.AddHobby(state, new AddHobbyAction(newHobby));

        Assert.Equal(2, result.Hobbies.Count);
    }

    // ── RemoveHobby ──────────────────────────────────────────────────────────

    [Fact]
    public void RemoveHobby_RemovesCorrectHobby()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var state = EmptyState() with
        {
            Hobbies = [new Hobby { Id = id1, Name = "Chess" }, new Hobby { Id = id2, Name = "Painting" }]
        };

        var result = UserAccountReducers.RemoveHobby(state, new RemoveHobbyAction(id1));

        Assert.Single(result.Hobbies);
        Assert.Equal(id2, result.Hobbies[0].Id);
    }

    [Fact]
    public void RemoveHobby_UnknownId_NoChange()
    {
        var hobby = new Hobby { Id = Guid.NewGuid(), Name = "Chess" };
        var state = EmptyState() with { Hobbies = [hobby] };

        var result = UserAccountReducers.RemoveHobby(state, new RemoveHobbyAction(Guid.NewGuid()));

        Assert.Single(result.Hobbies);
    }

    // ── ValidateHobbies ──────────────────────────────────────────────────────

    [Fact]
    public void ValidateHobbies_NoHobbies_Step2Invalid()
    {
        var result = UserAccountReducers.ValidateHobbies(EmptyState());
        Assert.False(result.Step2Valid);
    }

    [Fact]
    public void ValidateHobbies_AllValid_Step2Valid()
    {
        var state = EmptyState() with
        {
            Hobbies = [new Hobby { Name = "Chess" }, new Hobby { Name = "Painting" }]
        };
        var result = UserAccountReducers.ValidateHobbies(state);
        Assert.True(result.Step2Valid);
    }

    [Fact]
    public void ValidateHobbies_NameTooShort_Step2Invalid()
    {
        // Name must be > 3 chars
        var state = EmptyState() with { Hobbies = [new Hobby { Name = "Go" }] };
        var result = UserAccountReducers.ValidateHobbies(state);
        Assert.False(result.Step2Valid);
    }

    [Fact]
    public void ValidateHobbies_EmptyName_Step2Invalid()
    {
        var state = EmptyState() with { Hobbies = [new Hobby { Name = "" }] };
        var result = UserAccountReducers.ValidateHobbies(state);
        Assert.False(result.Step2Valid);
    }

    [Fact]
    public void ValidateHobbies_OneInvalidAmongMany_Step2Invalid()
    {
        var state = EmptyState() with
        {
            Hobbies = [new Hobby { Name = "Chess" }, new Hobby { Name = "Go" }]
        };
        var result = UserAccountReducers.ValidateHobbies(state);
        Assert.False(result.Step2Valid);
    }

    // ── AddVehicle ───────────────────────────────────────────────────────────

    [Fact]
    public void AddVehicle_AppendsVehicle()
    {
        var vehicle = new Vehicle { Id = Guid.NewGuid(), Make = "Toyota" };
        var result = UserAccountReducers.AddVehicle(EmptyState(), new AddVehicleAction(vehicle));
        Assert.Single(result.Vehicles);
        Assert.Equal(vehicle, result.Vehicles[0]);
    }

    // ── RemoveVehicle ────────────────────────────────────────────────────────

    [Fact]
    public void RemoveVehicle_RemovesCorrectVehicle()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var state = EmptyState() with
        {
            Vehicles = [new Vehicle { Id = id1 }, new Vehicle { Id = id2 }]
        };

        var result = UserAccountReducers.RemoveVehicle(state, new RemoveVehicleAction(id1));

        Assert.Single(result.Vehicles);
        Assert.Equal(id2, result.Vehicles[0].Id);
    }

    // ── ValidateVehicles ─────────────────────────────────────────────────────

    [Fact]
    public void ValidateVehicles_NoVehicles_Step3Invalid()
    {
        var result = UserAccountReducers.ValidateVehicles(EmptyState());
        Assert.False(result.Step3Valid);
    }

    [Fact]
    public void ValidateVehicles_AllValid_Step3Valid()
    {
        var state = EmptyState() with
        {
            Vehicles =
            [
                new Vehicle { Make = "Toyota", Model = "Yaris", LicensePlate = "AB-123-CD" }
            ]
        };
        var result = UserAccountReducers.ValidateVehicles(state);
        Assert.True(result.Step3Valid);
    }

    [Fact]
    public void ValidateVehicles_LicensePlateTooShort_Step3Invalid()
    {
        // LicensePlate must be > 7 chars
        var state = EmptyState() with
        {
            Vehicles = [new Vehicle { Make = "Toyota", Model = "Yaris", LicensePlate = "AB-123" }]
        };
        var result = UserAccountReducers.ValidateVehicles(state);
        Assert.False(result.Step3Valid);
    }

    [Fact]
    public void ValidateVehicles_ModelTooShort_Step3Invalid()
    {
        // Model must be >= 2 chars
        var state = EmptyState() with
        {
            Vehicles = [new Vehicle { Make = "Toyota", Model = "X", LicensePlate = "AB-123-CD" }]
        };
        var result = UserAccountReducers.ValidateVehicles(state);
        Assert.False(result.Step3Valid);
    }

    [Fact]
    public void ValidateVehicles_EmptyMake_Step3Invalid()
    {
        var state = EmptyState() with
        {
            Vehicles = [new Vehicle { Make = "", Model = "Yaris", LicensePlate = "AB-123-CD" }]
        };
        var result = UserAccountReducers.ValidateVehicles(state);
        Assert.False(result.Step3Valid);
    }

    // ── OnFinalize ───────────────────────────────────────────────────────────

    [Fact]
    public void OnFinalize_SetsIsSubmittedTrue()
    {
        var result = UserAccountReducers.OnFinalize(EmptyState());
        Assert.True(result.IsSubmitted);
    }

    // ── OnSaveAccount ────────────────────────────────────────────────────────

    [Fact]
    public void OnSaveAccount_UpdatesHobbiesAndVehicles_KeepsUserInfo()
    {
        var userInfo = new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" };
        var state = EmptyState() with { UserInfo = userInfo };

        var account = new UserAccountModel
        {
            Hobbies = [new Hobby { Name = "Chess" }],
            Vehicles = [new Vehicle { Make = "Toyota" }]
        };

        var result = UserAccountReducers.OnSaveAccount(state, new SaveAccountAction(account));

        Assert.Same(account.Hobbies, result.Hobbies);
        Assert.Same(account.Vehicles, result.Vehicles);
        Assert.Same(userInfo, result.UserInfo);
    }

    // ── OnReset ──────────────────────────────────────────────────────────────

    [Fact]
    public void OnReset_ReturnsDefaultState()
    {
        var dirty = EmptyState() with
        {
            Step1Valid = true,
            Step2Valid = true,
            IsSubmitted = true,
            Hobbies = [new Hobby { Name = "Chess" }]
        };

        var result = UserAccountReducers.OnReset(dirty);

        Assert.Equal(Guid.Empty, result.Id);
        Assert.False(result.Step1Valid);
        Assert.False(result.Step2Valid);
        Assert.False(result.Step3Valid);
        Assert.False(result.IsSubmitted);
        Assert.Empty(result.Hobbies);
        Assert.Empty(result.Vehicles);
    }
}
