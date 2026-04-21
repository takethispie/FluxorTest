using Domain.OffresCommerciales.Enums;
using Domain.OffresCommerciales.Interfaces;

namespace Domain.OffresCommerciales.Entities.Garanties;

public class RegroupementGaranties {
    public TypeRisque TypeRisque { get; }
    public List<IGarantie> Garanties { get; private set; }
    
    public RegroupementGaranties(TypeRisque risque, List<IGarantie> garanties) {
        Garanties = garanties;
        TypeRisque = risque;
    }
}