using Domain.OffresCommerciales.Entities.Garanties;

namespace Domain.OffresCommerciales.Interfaces;

public interface IProduit {
    List<RegroupementGaranties> RegroupementsGaranties { get; }
}