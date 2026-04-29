using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Garanties;

public abstract class GarantiePrevoyance : IGarantiePrevoyance
{
    public Guid Id { get; init; }
    public Libelle Libelle { get; init; }
    public Description Description { get; init; }

    protected GarantiePrevoyance(Guid id, Libelle libelle, Description description)
    {
        if(id == Guid.Empty) throw new ArgumentException("Id should not be empty GUID");
        Id = id;
        Libelle = libelle;
        Description = description;
    }
}
