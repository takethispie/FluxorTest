using Domain.OffresCommerciales.Interfaces;

namespace Domain.OffresCommerciales.Entities.Garanties;

public class RegroupementGaranties(List<IGarantie> garanties) {
    public List<IGarantie> Garanties { get; private set; } = garanties;
}