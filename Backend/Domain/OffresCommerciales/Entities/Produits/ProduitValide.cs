using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitValide<TRisque> : IProduit<TRisque>
    where TRisque : IGarantie
{
    public int Id { get; init; }
    public Libelle Libelle { get; private set; }
    public Description Description { get; private set; }
    public IEnumerable<TRisque> Garanties { get; private set; }

    public ProduitValide(
        int id,
        Libelle libelle,
        Description description,
        IEnumerable<TRisque> regroupementsGaranties
    ) {
        ArgumentOutOfRangeException.ThrowIfNegative(id);
        Id = id;
        Libelle = libelle;
        Description = description;
        Garanties = regroupementsGaranties;
    }

    public bool EstValide() {
        var valide = false;

        return valide;
    }
}
