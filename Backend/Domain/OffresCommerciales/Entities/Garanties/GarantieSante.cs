using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Garanties;

public abstract class GarantieSante : IGarantieSante
{
    public int Id { get; init; }
    public Libelle Libelle { get; init; }
    public Description Description { get; init; }

    protected GarantieSante(int id, Libelle libelle, Description description)
    {
        Id = id;
        Libelle = libelle;
        Description = description;
    }
}
