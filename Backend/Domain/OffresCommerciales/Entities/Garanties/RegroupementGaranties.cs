using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Garanties;

public class RegroupementGaranties<TRisque> : IGarantie where TRisque : IGarantie
{
    public IEnumerable<TRisque> Garanties { get; }

    public Guid Id { get; private set; }

    public Libelle Libelle { get; private set; }

    public Description Description { get; private set; }

    public RegroupementGaranties(IEnumerable<TRisque> garanties, Guid id, Libelle libelle, Description description)
    {
        var ty = typeof(TRisque);
        if (typeof(TRisque) != typeof(IGarantiePrevoyance) && typeof(TRisque) != typeof(IGarantieSante)) throw new Exception("missing subtyping");
        if(id == Guid.Empty) throw new ArgumentException("Id should not be empty GUID");
        Garanties = garanties;
        Id = id;
        Libelle = libelle;
        Description = description;
    }
}


public sealed class RegroupementGarantiesSante : RegroupementGaranties<IGarantieSante>
{
    public RegroupementGarantiesSante(
        IEnumerable<IGarantieSante> garanties,
        Guid id,
        Libelle libelle,
        Description description) : base(garanties, id, libelle, description) { }
}

public sealed class RegroupementGarantiesPrevoyance : RegroupementGaranties<IGarantiePrevoyance>
{
    public RegroupementGarantiesPrevoyance(
        IEnumerable<IGarantiePrevoyance> garanties,
        Guid id,
        Libelle libelle,
        Description description) : base(garanties, id, libelle, description) { }
}