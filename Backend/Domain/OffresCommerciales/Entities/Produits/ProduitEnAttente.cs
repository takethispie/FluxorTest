using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitEnAttente(Libelle libelle, Description description) : IProduit {
    public Description Description { get; init; } = description;
    public Libelle Libelle { get; init; } = libelle;
}