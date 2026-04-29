namespace FunctionalDomain

open System

module OffresCommerciale =

    type PrestationDetail = { Id: Guid; Libelle: string; Description: string }
    
    type Prestation =
        | Opticien of PrestationDetail
        | Dentiste of PrestationDetail

    type Client = { Id: Guid; Nom: string }
    
    type GarantieSante = { Id: int; Libelle: string; Description: string; Prestations: Prestation[] }

    type GarantiePrevoyance = { Id: int; Libelle: string; Description: string }
    

    type Garanties =
        | Sante of GarantieSante[]
        | Prevoyance of GarantiePrevoyance[]
        | Regroupement of Garanties[]
    
    type Produit =
        | Sante of Id: int * Garanties: Garanties[]
        | Prevoyance of Id: int * Garanties: Garanties[]
        
    type OffreCommerciale =
        | Brouillon of Id: Guid * Libelle: string * Description: string
        | Valide of Id: Guid * Libelle: string * Description: string