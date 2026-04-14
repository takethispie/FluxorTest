namespace Produit.Presentation.Client.Models;

public class UserInfo
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddYears(-18));
}

public class Hobby
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class Vehicle
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; } = DateTime.Today.Year;
    public string LicensePlate { get; set; } = string.Empty;
}

public class UserAccountModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public UserInfo UserInfo { get; set; } = new();
    public List<Hobby> Hobbies { get; set; } = [];
    public List<Vehicle> Vehicles { get; set; } = [];
    public bool EstBrouillon { get; set; }
}
