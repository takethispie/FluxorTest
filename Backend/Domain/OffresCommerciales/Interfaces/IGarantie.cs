using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Interfaces;

public interface IGarantie
{
    Guid Id { get; }
    Libelle Libelle { get; }
    Description Description { get; }
}

public interface IGarantieSante : IGarantie;
public interface IGarantiePrevoyance : IGarantie;
