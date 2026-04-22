using Domain.OffresCommerciales.Interfaces;

namespace Domain.OffresCommerciales.Entities.Garanties;

public abstract class GarantieSante : IGarantieSante
{
    public int Id { get; init; }
    public string Libelle { get; init; }
    public string Description { get; init; }

    protected GarantieSante(int id, string libelle, string description)
    {
        Id = id;
        Libelle = libelle;
        Description = description;
    }
}
