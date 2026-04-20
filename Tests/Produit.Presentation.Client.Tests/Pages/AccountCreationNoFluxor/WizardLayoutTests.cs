using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Produit.Presentation.Client.Models;
using Produit.Presentation.Client.Pages.AccountCreationNoFluxor;
using Produit.Presentation.Client.Services;

namespace Produit.Presentation.Client.Tests.Pages.AccountCreationNoFluxor;

public class WizardLayoutTests : TestContext
{
    private IRenderedComponent<WizardLayout> RenderWizard()
    {
        Services.AddSingleton<FakeAccountDatabase>();
        return RenderComponent<WizardLayout>();
    }

    // ── SaveUserInfo ─────────────────────────────────────────────────────────

    [Fact]
    public async Task SaveUserInfo_StoresUserInfo()
    {
        var cut = RenderWizard();
        var info = new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" };

        await cut.InvokeAsync(() => cut.Instance.SaveUserInfo(info));

        Assert.Equal("Alice", cut.Instance.UserInfo.FirstName);
        Assert.Equal("Smith", cut.Instance.UserInfo.LastName);
        Assert.Equal("a@b.com", cut.Instance.UserInfo.Email);
    }

    // ── ValidateUserInfo ─────────────────────────────────────────────────────

    [Fact]
    public async Task ValidateUserInfo_AllFieldsFilled_ReturnsTrue_SetsStep1Valid()
    {
        var cut = RenderWizard();
        bool result = false;

        await cut.InvokeAsync(() => { result = cut.Instance.ValidateUserInfo("Alice", "Smith", "a@b.com"); });

        Assert.True(result);
        Assert.True(cut.Instance.Step1Valid);
    }

    [Theory]
    [InlineData("", "Smith", "a@b.com")]
    [InlineData("Alice", "", "a@b.com")]
    [InlineData("Alice", "Smith", "")]
    [InlineData("  ", "Smith", "a@b.com")]
    public async Task ValidateUserInfo_MissingField_ReturnsFalse_Step1ValidFalse(string fn, string ln, string email)
    {
        var cut = RenderWizard();
        bool result = true;

        await cut.InvokeAsync(() => { result = cut.Instance.ValidateUserInfo(fn, ln, email); });

        Assert.False(result);
        Assert.False(cut.Instance.Step1Valid);
    }

    // ── AddHobby / RemoveHobby ───────────────────────────────────────────────

    [Fact]
    public async Task AddHobby_AppendsToList()
    {
        var cut = RenderWizard();
        var hobby = new Hobby { Id = Guid.NewGuid(), Name = "Chess" };

        await cut.InvokeAsync(() => cut.Instance.AddHobby(hobby));

        Assert.Single(cut.Instance.Hobbies);
        Assert.Equal("Chess", cut.Instance.Hobbies[0].Name);
    }

    [Fact]
    public async Task RemoveHobby_RemovesById()
    {
        var cut = RenderWizard();
        var id = Guid.NewGuid();

        await cut.InvokeAsync(() =>
        {
            cut.Instance.AddHobby(new Hobby { Id = id, Name = "Chess" });
            cut.Instance.AddHobby(new Hobby { Id = Guid.NewGuid(), Name = "Reading" });
            cut.Instance.RemoveHobby(id);
        });

        Assert.Single(cut.Instance.Hobbies);
        Assert.Equal("Reading", cut.Instance.Hobbies[0].Name);
    }

    // ── ValidateHobbies ──────────────────────────────────────────────────────

    [Fact]
    public async Task ValidateHobbies_WithHobbies_ReturnsTrue_SetsStep2Valid()
    {
        var cut = RenderWizard();
        bool result = false;

        await cut.InvokeAsync(() =>
        {
            cut.Instance.AddHobby(new Hobby { Name = "Chess" });
            result = cut.Instance.ValidateHobbies();
        });

        Assert.True(result);
        Assert.True(cut.Instance.Step2Valid);
    }

    [Fact]
    public async Task ValidateHobbies_NoHobbies_ReturnsFalse_Step2ValidFalse()
    {
        var cut = RenderWizard();
        bool result = true;

        await cut.InvokeAsync(() => { result = cut.Instance.ValidateHobbies(); });

        Assert.False(result);
        Assert.False(cut.Instance.Step2Valid);
    }

    // ── AddVehicle / RemoveVehicle ───────────────────────────────────────────

    [Fact]
    public async Task AddVehicle_AppendsToList()
    {
        var cut = RenderWizard();
        var vehicle = new Vehicle { Id = Guid.NewGuid(), Make = "Toyota", Model = "Corolla" };

        await cut.InvokeAsync(() => cut.Instance.AddVehicle(vehicle));

        Assert.Single(cut.Instance.Vehicles);
        Assert.Equal("Toyota", cut.Instance.Vehicles[0].Make);
    }

    [Fact]
    public async Task RemoveVehicle_RemovesById()
    {
        var cut = RenderWizard();
        var id = Guid.NewGuid();

        await cut.InvokeAsync(() =>
        {
            cut.Instance.AddVehicle(new Vehicle { Id = id, Make = "Toyota", Model = "Corolla" });
            cut.Instance.AddVehicle(new Vehicle { Id = Guid.NewGuid(), Make = "Honda", Model = "Civic" });
            cut.Instance.RemoveVehicle(id);
        });

        Assert.Single(cut.Instance.Vehicles);
        Assert.Equal("Honda", cut.Instance.Vehicles[0].Make);
    }

    // ── ValidateVehicles ─────────────────────────────────────────────────────

    [Fact]
    public async Task ValidateVehicles_WithVehicles_ReturnsTrue_SetsStep3Valid()
    {
        var cut = RenderWizard();
        bool result = false;

        await cut.InvokeAsync(() =>
        {
            cut.Instance.AddVehicle(new Vehicle { Make = "Toyota", Model = "Corolla" });
            result = cut.Instance.ValidateVehicles();
        });

        Assert.True(result);
        Assert.True(cut.Instance.Step3Valid);
    }

    [Fact]
    public async Task ValidateVehicles_NoVehicles_ReturnsFalse_Step3ValidFalse()
    {
        var cut = RenderWizard();
        bool result = true;

        await cut.InvokeAsync(() => { result = cut.Instance.ValidateVehicles(); });

        Assert.False(result);
        Assert.False(cut.Instance.Step3Valid);
    }

    // ── SubmitAccount ────────────────────────────────────────────────────────

    [Fact]
    public async Task SubmitAccount_SetsIsSubmitted()
    {
        var cut = RenderWizard();

        await cut.InvokeAsync(() =>
        {
            cut.Instance.SaveUserInfo(new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" });
            cut.Instance.SubmitAccount();
        });

        Assert.True(cut.Instance.IsSubmitted);
    }


    // ── Reset ────────────────────────────────────────────────────────────────

    [Fact]
    public async Task Reset_ClearsAllStateAndFlags()
    {
        var cut = RenderWizard();
        Guid idBefore = Guid.Empty;

        await cut.InvokeAsync(() =>
        {
            cut.Instance.SaveUserInfo(new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" });
            cut.Instance.ValidateUserInfo("Alice", "Smith", "a@b.com");
            cut.Instance.AddHobby(new Hobby { Name = "Chess" });
            cut.Instance.ValidateHobbies();
            cut.Instance.AddVehicle(new Vehicle { Make = "Toyota", Model = "Corolla" });
            cut.Instance.ValidateVehicles();
            cut.Instance.SubmitAccount();
            idBefore = cut.Instance.Id;
            cut.Instance.Reset();
        });

        Assert.NotEqual(idBefore, cut.Instance.Id);
        Assert.Equal(string.Empty, cut.Instance.UserInfo.FirstName);
        Assert.Empty(cut.Instance.Hobbies);
        Assert.Empty(cut.Instance.Vehicles);
        Assert.False(cut.Instance.Step1Valid);
        Assert.False(cut.Instance.Step2Valid);
        Assert.False(cut.Instance.Step3Valid);
        Assert.False(cut.Instance.IsSubmitted);
    }
}
