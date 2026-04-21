using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Enums;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnGestion : IProduit {
    public int Id { get; init; }
    public Description Description { get; init; }
    public Libelle Libelle { get; init; }
    public IEnumerable<RegroupementGaranties> RegroupementsGaranties { get; }
    public TypeRisque Type { get; }

    public ProduitEnGestion(
        int id, 
        Libelle libelle, 
        Description description, 
        List<RegroupementGaranties> regroupementsGaranties,
        TypeRisque type
    ) {
        Id = id;
        Type = type;
        Description = description;
        Libelle = libelle;
        RegroupementsGaranties = regroupementsGaranties;
    }
    
    public void AjouterGarantie(IGarantie garantie) {
        
    }
}
