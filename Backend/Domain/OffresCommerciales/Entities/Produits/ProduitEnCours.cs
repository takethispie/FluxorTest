using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnCours<TRisque> : IProduit<TRisque>
    where TRisque : IGarantie
{
    public int Id { get; init; }
    public string Libelle { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<RegroupementGaranties<TRisque>> RegroupementsGaranties { get; private set; }

    public ProduitEnCours(
        int id,
        string libelle,
        string description,
        List<RegroupementGaranties<TRisque>> regroupementsGaranties
    ) {
        Id = id;
        Libelle = libelle;
        Description = description;
        RegroupementsGaranties = regroupementsGaranties;
    }

    public bool EstValide() => false;

    public IProduit<TRisque> Valider() => this switch {
        {
            Libelle: not null and not "",
            Libelle.Length: <= 100,
            Description: not null and not "",
            Description.Length: <= 1000
        } => new ProduitValide<TRisque>(Id, new Libelle(Libelle), new Description(Description), RegroupementsGaranties),
        _ => this
    };
}
