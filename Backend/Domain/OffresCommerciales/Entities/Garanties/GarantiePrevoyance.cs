using Domain.OffresCommerciales.Interfaces;

namespace Domain.OffresCommerciales.Entities.Garanties;

public abstract class GarantiePrevoyance : IGarantiePrevoyance
{
    public int Id { get; init; }
    public string Libelle { get; init; }
    public string Description { get; init; }

    protected GarantiePrevoyance(int id, string libelle, string description)
    {
        Id = id;
        Libelle = libelle;
        Description = description;
    }
}
