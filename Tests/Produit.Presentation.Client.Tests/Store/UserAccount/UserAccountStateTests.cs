using Produit.Presentation.Client.Models;
using Produit.Presentation.Client.Store.UserAccount;

namespace Produit.Presentation.Client.Tests.Store.UserAccount;

public class UserAccountStateTests
{
    // ── ToUserAccountModel ───────────────────────────────────────────────────

    [Fact]
    public void ToUserAccountModel_MapsAllFields()
    {
        var id = Guid.NewGuid();
        var userInfo = new UserInfo { FirstName = "Alice", LastName = "Smith", Email = "a@b.com" };
        var hobbies = new List<Hobby> { new() { Name = "Chess" } };
        var vehicles = new List<Vehicle> { new() { Make = "Toyota" } };

        var state = new UserAccountState
        {
            Id = id,
            UserInfo = userInfo,
            Hobbies = hobbies,
            Vehicles = vehicles,
            Step1Valid = true,
            Step2Valid = true,
            Step3Valid = true
        };

        var model = state.ToUserAccountModel();

        Assert.Equal(id, model.Id);
        Assert.Same(userInfo, model.UserInfo);
        Assert.Same(hobbies, model.Hobbies);
        Assert.Same(vehicles, model.Vehicles);
    }

    [Fact]
    public void ToUserAccountModel_AllStepsValid_EstBrouillonFalse()
    {
        var state = new UserAccountState { Step1Valid = true, Step2Valid = true, Step3Valid = true };
        Assert.False(state.ToUserAccountModel().EstBrouillon);
    }

    [Theory]
    [InlineData(false, true, true)]
    [InlineData(true, false, true)]
    [InlineData(true, true, false)]
    [InlineData(false, false, false)]
    public void ToUserAccountModel_AnyStepInvalid_EstBrouillonTrue(bool s1, bool s2, bool s3)
    {
        var state = new UserAccountState { Step1Valid = s1, Step2Valid = s2, Step3Valid = s3 };
        Assert.True(state.ToUserAccountModel().EstBrouillon);
    }

    [Fact]
    public void DefaultState_AllFlagsAreFalse()
    {
        var state = new UserAccountState();
        Assert.False(state.Step1Valid);
        Assert.False(state.Step2Valid);
        Assert.False(state.Step3Valid);
        Assert.False(state.IsSubmitted);
        Assert.Equal(Guid.Empty, state.Id);
        Assert.Empty(state.Hobbies);
        Assert.Empty(state.Vehicles);
    }
}
