using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnAttente<TRisque> : IProduit<TRisque>
    where TRisque : IGarantie
{
    public int Id { get; init; }
    public Libelle Libelle { get; init; }
    public Description Description { get; init; }
    public IEnumerable<RegroupementGaranties<TRisque>> RegroupementsGaranties { get; private set; }

    public ProduitEnAttente(
        int id,
        Libelle libelle,
        Description description,
        IEnumerable<RegroupementGaranties<TRisque>> regroupementsGaranties
    ) {
        Id = id;
        Libelle = libelle;
        Description = description;
        RegroupementsGaranties = regroupementsGaranties;
    }
}
