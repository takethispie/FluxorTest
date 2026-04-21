using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Entities.Produits;
using Domain.OffresCommerciales.Enums;

namespace Domain.OffresCommerciales.Interfaces;

public interface IProduit {
    int Id { get; }
    IEnumerable<RegroupementGaranties> RegroupementsGaranties { get; }
    TypeRisque Type { get; }

    void AjouterGarantie(IGarantie garantie);
}