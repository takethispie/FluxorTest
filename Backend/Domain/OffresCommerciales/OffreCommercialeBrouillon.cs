using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales;

public class OffreCommercialeBrouillon(Guid id, string libelle, string description, List<IProduit> produits) : IOffreCommerciale {
    public Guid Id { get; private set; } = id;
    public string Libelle { get; private set; } = libelle;
    public string Description { get; private set; } = description;
    public List<IProduit> Produits { get; private set; } = produits;

    public IOffreCommerciale Validate() => this switch {
        {
            Libelle: not null and not "", 
            Libelle.Length: < 1000, 
            Description: not null and not "",
            Description.Length: < 80,
            Produits.Count: > 0
        } => new OffreCommercialeValide(Id, new Libelle(Libelle), new Description(Description)),
        _ => this
    };
}