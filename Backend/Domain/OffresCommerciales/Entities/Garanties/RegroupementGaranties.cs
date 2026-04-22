using Domain.OffresCommerciales.Interfaces;

namespace Domain.OffresCommerciales.Entities.Garanties;

public class RegroupementGaranties<TRisque> where TRisque : IGarantie
{
    public IReadOnlyList<TRisque> Garanties { get; }

    public RegroupementGaranties(IEnumerable<TRisque> garanties)
    {
        Garanties = garanties.ToList().AsReadOnly();
    }
}


public sealed class RegroupementGarantiesSante : RegroupementGaranties<IGarantieSante>
{
    public RegroupementGarantiesSante(IEnumerable<IGarantieSante> garanties) : base(garanties) { }
}

public sealed class RegroupementGarantiesPrevoyance : RegroupementGaranties<IGarantiePrevoyance>
{
    public RegroupementGarantiesPrevoyance(IEnumerable<IGarantiePrevoyance> garanties) : base(garanties) { }
}
