using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnGestion : IProduit {
    public Description Description { get; init; }
    public Libelle Libelle { get; init; }
    public List<RegroupementGaranties> RegroupementsGaranties { get; }
    
    public ProduitEnGestion(Libelle libelle, Description description, List<RegroupementGaranties> regroupementsGaranties) {
        Description = description;
        Libelle = libelle;
        RegroupementsGaranties = regroupementsGaranties;
    }
}
