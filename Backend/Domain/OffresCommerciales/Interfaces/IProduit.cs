using Domain.OffresCommerciales.Entities.Garanties;

namespace Domain.OffresCommerciales.Interfaces;

public interface IProduit
{
    int Id { get; }
    bool EstValide();
}

public interface IProduit<TGarantie> : IProduit where TGarantie : IGarantie
{
    IEnumerable<RegroupementGaranties<TGarantie>> RegroupementsGaranties { get; }
}
