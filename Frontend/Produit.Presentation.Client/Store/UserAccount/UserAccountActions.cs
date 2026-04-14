using Produit.Presentation.Client.Models;

namespace Produit.Presentation.Client.Store.UserAccount;

// Step 1
public record SaveUserInfoAction(UserInfo UserInfo);
public record ValidateUserInfoAction(string FirstName, string LastName, string Email);

// Step 2
public record AddHobbyAction(Hobby Hobby);
public record RemoveHobbyAction(Guid HobbyId);
public record SaveHobbiesAction();
public record ValidateHobbiesAction();

// Step 3
public record AddVehicleAction(Vehicle Vehicle);
public record RemoveVehicleAction(Guid VehicleId);
public record SaveVehiclesAction();
public record ValidateVehiclesAction();

// Global
public record LoadAccountForEditAction(UserAccountModel Account);
public record SaveAccountAction(UserAccountModel Account);
public record FinalizeAccountAction(UserAccountModel Account);
public record ResetAccountAction();
