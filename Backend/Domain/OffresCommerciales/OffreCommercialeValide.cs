using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales;

public class OffreCommercialeValide : IOffreCommerciale
{
    public Guid Id { get; private set; }
    public Libelle Libelle { get; private set; }
    public Description Description { get; private set; }
    public IEnumerable<IProduit> Produits { get; private set; }

    public OffreCommercialeValide(Guid id, Libelle libelle, Description description, List<IProduit> produits)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id should not be empty");
        if (!produits.Any())
            throw new ArgumentException("there should be at least one produit");

        Id = id;
        Produits = produits;
        Description = description ?? throw new ArgumentException("Description should not be null");
        Libelle = libelle ?? throw new ArgumentException("Libelle should not be null");
    }

    public void AjouterProduit(IProduit produit)
    {
        throw new NotImplementedException();
    }

    public void SupprimerProduit(IProduit produit)
    {
        throw new NotImplementedException();
    }
}
