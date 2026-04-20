using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitBrouillon(string libelle, string description) : IProduit {
    public string Libelle { get; private set; } = libelle;
    public string Description { get; private set; } = description;
    
    public IProduit Validate() => this switch {
        { Libelle: not null and not "", Libelle.Length: < 1000, Description: not null and not "" } 
            => new ProduitEnAttente(new Libelle(Libelle), new Description(Description)),
        _ => this
    };
}