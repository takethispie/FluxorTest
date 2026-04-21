using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Enums;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnAttente : IProduit {
    public int Id { get; init; }
    public Description Description { get; init; }
    public Libelle Libelle { get; init; }
    public IEnumerable<RegroupementGaranties> RegroupementsGaranties { get; private set; }
    public TypeRisque Type { get; }

    public ProduitEnAttente(int id, Libelle libelle, Description description, IEnumerable<RegroupementGaranties> regroupementsGaranties, TypeRisque type) {
        Id = id;
        Description = description;
        Libelle = libelle;
        RegroupementsGaranties = regroupementsGaranties;
        Type = type;
    }
    
    public void AjouterGarantie(IGarantie garantie) {
        throw new NotImplementedException();
    }
}
