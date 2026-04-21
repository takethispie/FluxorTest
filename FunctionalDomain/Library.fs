namespace FunctionalDomain

open System

module Offre =
    
    type Prestation =
        | Opticien of Id: int * Description: string
    
    type Garantie =
        | Sante of Id: int * Libelle: string * Description: string
    
    type RegroupementGaranties =
        | Sante of Garanties: Garantie[]
        | Prevoyance of Garanties: Garantie[]
    
    type Produit =
        | Sante of Id: int * RegroupementGaranties: RegroupementGaranties[] 
    type OffreCommerciale =
        | Brouillon of Id: Guid
        | Valide of Id: Guid * Libelle: string * Description: string 