using Fluxor;
using Produit.Presentation.Client.Models;

namespace Produit.Presentation.Client.Store.UserAccount;

[FeatureState]
public record UserAccountState
{
    public Guid Id { get; init; } = Guid.Empty;
    public UserInfo UserInfo { get; init; } = new();
    public List<Hobby> Hobbies { get; init; } = [];
    public List<Vehicle> Vehicles { get; init; } = [];
    public bool Step1Valid { get; init; } = false;
    public bool Step2Valid { get; init; } = false;
    public bool Step3Valid { get; init; } = false;
    public bool IsSubmitted { get; init; } = false;

    public UserAccountState() { }

    public UserAccountModel ToUserAccountModel() => new UserAccountModel() {
        Id = Id,
        UserInfo = UserInfo,
        Hobbies = Hobbies,
        Vehicles = Vehicles,
        EstBrouillon = !Step1Valid || !Step2Valid || !Step3Valid
    };
}
