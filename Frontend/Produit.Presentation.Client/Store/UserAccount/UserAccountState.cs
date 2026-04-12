using Fluxor;

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
}
