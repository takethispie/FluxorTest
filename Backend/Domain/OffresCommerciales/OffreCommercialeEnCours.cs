using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales;

public class OffreCommercialeEnCours : IOffreCommerciale
{
    public Guid Id { get; private set; }
    public string Libelle { get; private set; }
    public string Description { get; private set; }
    public IEnumerable<IProduit> Produits { get; private set; }
    public IEnumerable<IGarantie> Garanties { get; private set; }
    public IEnumerable<IPopulation> Populations { get; private set; }

    public OffreCommercialeEnCours(
        Guid id,
        string libelle,
        string description,
        List<IProduit> produits,
        List<IGarantie> garanties,
        List<IPopulation> populations)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id cannot be an empty GUID");
        Id = id;
        Libelle = libelle;
        Description = description;
        Produits = produits;
        Garanties = garanties;
        Populations = populations;
    }

    public IOffreCommerciale Validate() => this switch
    {
        {
            Libelle.Length: > 0 and <= 1000,
            Description.Length: > 0 and <= 100,
        } when Id != Guid.Empty &&  Produits.Any() => new OffreCommercialeValide(
            Id,
            new Libelle(Libelle),
            new Description(Description),
            [..Produits],
            [..Garanties],
            [..Populations]
        ),
        _ => this
    };
}
