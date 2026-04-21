using Domain.OffresCommerciales.Entities.Garanties;
using Domain.OffresCommerciales.Enums;
using Domain.OffresCommerciales.Interfaces;
using Domain.OffresCommerciales.ValueObjects;

namespace Domain.OffresCommerciales.Entities.Produits;

public class ProduitBrouillon : IProduit {
    public int Id { get; init; }
    public string Libelle { get; private set; }
    public string Description { get; private set; }
    public TypeRisque Type { get; init; }
    public IEnumerable<RegroupementGaranties> RegroupementsGaranties { get; private set; }
    
    public ProduitBrouillon(
        int id,
        string libelle,
        string description,
        List<RegroupementGaranties> regroupementsGaranties,
        TypeRisque type
    ) {
        Id = id;
        Libelle = libelle;
        Description = description;
        RegroupementsGaranties = regroupementsGaranties;
        Type = type;
    }
    
    public void AjouterGarantie(IGarantie garantie) {
        throw new NotImplementedException();
    }
    
    public IProduit Validate() => this switch {
        {
            Libelle: not null and not "", 
            Libelle.Length: <= 100, 
            Description: not null and not "",
            Description.Length: <= 1000
        } => new ProduitEnAttente(Id, new Libelle(Libelle), new Description(Description), RegroupementsGaranties, Type),
        _ => this
    };

}