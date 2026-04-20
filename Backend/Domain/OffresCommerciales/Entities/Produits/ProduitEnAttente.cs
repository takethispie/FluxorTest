using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnAttente : IProduit {
    public Description Description { get; init; }
    public Libelle Libelle { get; init; }
    public List<RegroupementGaranties> RegroupementsGaranties { get; private set; }
    
    public ProduitEnAttente(Libelle libelle, Description description, List<RegroupementGaranties> regroupementsGaranties) {
        Description = description;
        Libelle = libelle;
        RegroupementsGaranties = regroupementsGaranties;
    }
}
