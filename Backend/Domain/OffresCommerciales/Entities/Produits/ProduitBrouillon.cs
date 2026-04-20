using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitBrouillon : IProduit {
    public string Libelle { get; private set; }
    public string Description { get; private set; }
    public List<RegroupementGaranties> RegroupementsGaranties { get; private set; }
    
    public ProduitBrouillon(string libelle, string description, List<RegroupementGaranties> regroupementsGaranties) {
        Libelle = libelle;
        Description = description;
        RegroupementsGaranties = regroupementsGaranties;
    }
    
    public IProduit Validate() => this switch {
        {
            Libelle: not null and not "", 
            Libelle.Length: <= 100, 
            Description: not null and not "",
            Description.Length: <= 1000
        } => new ProduitEnAttente(new Libelle(Libelle), new Description(Description), RegroupementsGaranties),
        _ => this
    };

}