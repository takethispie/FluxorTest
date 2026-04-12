namespace Produit.Presentation.Client.Store.UserAccount;

// Step 1
public record SaveUserInfoAction(UserInfo UserInfo);
public record ValidateStep1Action();

// Step 2
public record AddHobbyAction(Hobby Hobby);
public record RemoveHobbyAction(Guid HobbyId);
public record SaveStep2Action();
public record ValidateStep2Action();

// Step 3
public record AddVehicleAction(Vehicle Vehicle);
public record RemoveVehicleAction(Guid VehicleId);
public record ValidateStep3Action();

// Global
public record LoadAccountForEditAction(UserAccountModel Account);
public record SaveAccountAction(UserAccountModel Account);
public record FinalizeAccountAction(UserAccountModel Account);
public record ResetAccountAction();
