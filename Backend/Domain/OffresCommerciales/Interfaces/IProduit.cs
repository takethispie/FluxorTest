using Domain.OffresCommerciales.Entities.Garanties;

namespace Domain.OffresCommerciales.Interfaces;

/// <summary>Non-generic base — allows heterogeneous produit collections in OffreCommerciale.</summary>
public interface IProduit
{
    int Id { get; }
}

/// <summary>
/// Generic produit — TGarantie constrains which regroupements are allowed,
/// making it impossible to add Prevoyance regroupements to a Sante produit and vice-versa.
/// </summary>
public interface IProduit<TGarantie> : IProduit where TGarantie : IGarantie
{
    IEnumerable<RegroupementGaranties<TGarantie>> RegroupementsGaranties { get; }
}
