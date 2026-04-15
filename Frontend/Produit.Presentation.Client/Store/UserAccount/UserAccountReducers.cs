using Fluxor;

namespace Produit.Presentation.Client.Store.UserAccount;

public static class UserAccountReducers
{
    [ReducerMethod]
    public static UserAccountState LoadForEdit(UserAccountState s, LoadAccountForEditAction a) =>
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
    public static UserAccountState SaveUserInfo(UserAccountState _, SaveUserInfoAction a) => a.NewAccountState;

    [ReducerMethod]
    public static UserAccountState ValidateUserInfo(UserAccountState s, ValidateUserInfoAction a) =>
        s with
        {
            Step1Valid = !string.IsNullOrWhiteSpace(a.FirstName)
                      && !string.IsNullOrWhiteSpace(a.LastName)
                      && !string.IsNullOrWhiteSpace(a.Email)
        };

    [ReducerMethod]
    public static UserAccountState AddHobby(UserAccountState s, AddHobbyAction a) =>
        s with { Hobbies = [..s.Hobbies, a.Hobby] };

    [ReducerMethod]
    public static UserAccountState RemoveHobby(UserAccountState s, RemoveHobbyAction a) =>
        s with { Hobbies = s.Hobbies.Where(h => h.Id != a.HobbyId).ToList() };

    [ReducerMethod(typeof(SaveHobbiesAction))]
    public static UserAccountState SaveHobbies(UserAccountState s) => s;

    [ReducerMethod(typeof(ValidateHobbiesAction))]
    public static UserAccountState ValidateHobbies(UserAccountState s) =>
        s with {
            Step2Valid = s.Hobbies.Count > 0 && s.Hobbies.All(
                hobby => !string.IsNullOrEmpty(hobby.Name)
                && hobby.Name.Length > 3
            )
        };

    [ReducerMethod]
    public static UserAccountState AddVehicle(UserAccountState s, AddVehicleAction a) =>
        s with { Vehicles = [..s.Vehicles, a.Vehicle] };

    [ReducerMethod]
    public static UserAccountState RemoveVehicle(UserAccountState s, RemoveVehicleAction a) =>
        s with { Vehicles = s.Vehicles.Where(v => v.Id != a.VehicleId).ToList() };

    [ReducerMethod(typeof(ValidateVehiclesAction))]
    public static UserAccountState ValidateVehicles(UserAccountState s) =>
        s with {
            Step3Valid = s.Vehicles.Count > 0 && s.Vehicles.All(
                ve => !string.IsNullOrEmpty(ve.LicensePlate)
                &&  !string.IsNullOrWhiteSpace(ve.Make)
                && !string.IsNullOrWhiteSpace(ve.Model)
                && ve.LicensePlate.Length > 7
                && ve.Model.Length >= 2
            )
        };

    [ReducerMethod(typeof(FinalizeAccountAction))]
    public static UserAccountState OnFinalize(UserAccountState s) =>
        s with { IsSubmitted = true  };

    [ReducerMethod]
    public static UserAccountState OnSaveAccount(UserAccountState s, SaveAccountAction action) =>
        s with { Hobbies = action.Account.Hobbies, Vehicles = action.Account.Vehicles, UserInfo =  s.UserInfo };

    [ReducerMethod(typeof(ResetAccountAction))]
    public static UserAccountState OnReset(UserAccountState _) => new();
}
