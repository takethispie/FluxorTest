using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnGestion<TGarantie> : IProduit<TGarantie>
    where TGarantie : IGarantie
{
    public int Id { get; init; }
    public Libelle Libelle { get; init; }
    public Description Description { get; init; }
    public IEnumerable<RegroupementGaranties<TGarantie>> RegroupementsGaranties { get; }

    public ProduitEnGestion(
        int id,
        Libelle libelle,
        Description description,
        List<RegroupementGaranties<TGarantie>> regroupementsGaranties
    ) {
        Id = id;
        Libelle = libelle;
        Description = description;
        RegroupementsGaranties = regroupementsGaranties;
    }
}
