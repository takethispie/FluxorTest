namespace Domain.OffresCommerciales.Interfaces;

public interface IGarantie
{
    int Id { get; }
    string Libelle { get; }
    string Description { get; }
}

public interface IGarantieSante : IGarantie;
public interface IGarantiePrevoyance : IGarantie;
