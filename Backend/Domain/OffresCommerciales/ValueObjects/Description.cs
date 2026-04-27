using Domain.OffresCommerciales.Exceptions;

namespace Domain.OffresCommerciales.ValueObjects;

public class Description {
    public string Valeur { get; }

    public Description(string valeur) {
        if(string.IsNullOrWhiteSpace(valeur) || valeur.Length > 1000)
            throw new IncorrectDescriptionException("");
        Valeur = valeur;
    }
}