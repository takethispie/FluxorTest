namespace Domain.OffresCommerciales.Interfaces;

public interface IOffreCommerciale {
    Guid Id { get; }
    void AjouterProduit(IProduit produit);
    void SupprimerProduit(IProduit produit);
}