using Domain.OffresCommerciales.Exceptions;

namespace Domain.OffresCommerciales.ValueObjects;

public class Libelle {
    public string Valeur { get; }
    
    public Libelle(string valeur) {
        if (string.IsNullOrWhiteSpace(valeur.Trim()) || valeur.Length > 80)
            throw new IncorrectLibelleException("");
        Valeur = valeur;
    }
}