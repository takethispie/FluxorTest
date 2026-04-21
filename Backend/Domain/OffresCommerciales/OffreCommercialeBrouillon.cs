using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Entities.Produits;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales;

public class OffreCommercialeBrouillon : IOffreCommerciale {
    public Guid Id { get; private set; }
    public string Libelle { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<IProduit> Produits { get; private set; }

    public OffreCommercialeBrouillon(Guid id, string libelle, string description, List<IProduit> produits) {
        Id = id;
        Libelle = libelle;
        Description = description;
        Produits = produits;
    }

    public void AjouterProduit(IProduit produit) {
        Produits = Produits.Append(produit);
    }

    public void SupprimerProduit(IProduit produit) {
        Produits = Produits.Where(x => x.Id != produit.Id);
    }
    
    public IOffreCommerciale Validate() => this switch {
        {
            Libelle.Length: > 0 and <= 1000, 
            Description.Length: > 0 and <= 100,
        } when Produits.Any(x => x is ProduitEnAttente) => new OffreCommercialeValide(
            Id, 
            new Libelle(Libelle), 
            new Description(Description), 
            Produits.ToList()
        ),
        _ => this
    };
}