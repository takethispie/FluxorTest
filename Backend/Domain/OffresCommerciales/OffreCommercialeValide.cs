using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales;

public class OffreCommercialeValide(Guid id, Libelle libelle, Description description) : IOffreCommerciale {
    public Guid Id { get; private set; } = id;
    public Description Description { get; private set; } = description;
    public Libelle Libelle { get; private set; } = libelle;
}