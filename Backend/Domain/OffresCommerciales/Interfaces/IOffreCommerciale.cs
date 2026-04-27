namespace Domain.OffresCommerciales.Interfaces;

public interface IOffreCommerciale
{
    Guid Id { get; }
    public IEnumerable<IProduit> Produits { get; }
    public IEnumerable<IGarantie> Garanties { get; }
    public IEnumerable<IPopulation> Populations { get; }
}
