using Fluxor;

namespace Produit.Presentation.Client.Store.UserAccount;

public static class UserAccountReducers
{
    [ReducerMethod]
    public static UserAccountState OnLoadForEdit(UserAccountState s, LoadAccountForEditAction a) =>
        s with
        {
            Id = a.Account.Id,
            UserInfo = a.Account.UserInfo,
            Hobbies = a.Account.Hobbies,
            Vehicles = a.Account.Vehicles,
            Step1Valid = true,
            Step2Valid = a.Account.Hobbies.Count > 0,
            Step3Valid = a.Account.Vehicles.Count > 0,
            IsSubmitted = false
        };

    [ReducerMethod]
    public static UserAccountState OnSaveUserInfo(UserAccountState s, SaveUserInfoAction a) =>
        s with { UserInfo = a.UserInfo };

    [ReducerMethod(typeof(ValidateStep1Action))]
    public static UserAccountState OnValidateStep1(UserAccountState s) =>
        s with
        {
            Step1Valid = !string.IsNullOrWhiteSpace(s.UserInfo.FirstName)
                      && !string.IsNullOrWhiteSpace(s.UserInfo.LastName)
                      && !string.IsNullOrWhiteSpace(s.UserInfo.Email)
        };

    [ReducerMethod]
    public static UserAccountState OnAddHobby(UserAccountState s, AddHobbyAction a) =>
        s with { Hobbies = [..s.Hobbies, a.Hobby] };

    [ReducerMethod]
    public static UserAccountState OnRemoveHobby(UserAccountState s, RemoveHobbyAction a) =>
        s with { Hobbies = s.Hobbies.Where(h => h.Id != a.HobbyId).ToList() };

    [ReducerMethod(typeof(SaveHobbiesAction))]
    public static UserAccountState OnSaveStep2(UserAccountState s) => s;

    [ReducerMethod(typeof(ValidateHobbiesAction))]
    public static UserAccountState OnValidateStep2(UserAccountState s) =>
        s with { Step2Valid = s.Hobbies.Count > 0 };

    [ReducerMethod]
    public static UserAccountState OnAddVehicle(UserAccountState s, AddVehicleAction a) =>
        s with { Vehicles = [..s.Vehicles, a.Vehicle] };

    [ReducerMethod]
    public static UserAccountState OnRemoveVehicle(UserAccountState s, RemoveVehicleAction a) =>
        s with { Vehicles = s.Vehicles.Where(v => v.Id != a.VehicleId).ToList() };

    [ReducerMethod(typeof(ValidateVehiclesAction))]
    public static UserAccountState OnValidateStep3(UserAccountState s) =>
        s with { Step3Valid = s.Vehicles.Count > 0 };

    [ReducerMethod(typeof(FinalizeAccountAction))]
    public static UserAccountState OnFinalize(UserAccountState s) =>
        s with { IsSubmitted = true };

    [ReducerMethod(typeof(SaveAccountAction))]
    public static UserAccountState OnSaveAccount(UserAccountState s) => s;

    [ReducerMethod(typeof(ResetAccountAction))]
    public static UserAccountState OnReset(UserAccountState _) => new();
}
