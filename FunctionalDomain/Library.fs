namespace FunctionalDomain

open System

module Offre =

    type PrestationDetail = { Id: Guid; Libelle: string; Description: string }
    
    type Prestation =
        | Opticien of PrestationDetail
        | Dentiste of PrestationDetail

    type Client = { Id: Guid; Nom: string }
    
    type GarantieSante = { Id: int; Libelle: string; Description: string; Prestations: Prestation[] }

    type GarantiePrevoyance = { Id: int; Libelle: string; Description: string }
    
    type RegroupementGaranties<'risque> = RegroupementGaranties of Garanties: 'risque[]
    
    type Produit =
        | Sante of Id: int * RegroupementGaranties: RegroupementGaranties<GarantieSante>[]
        | Prevoyance of Id: int * RegroupementGaranties: RegroupementGaranties<GarantiePrevoyance>[]
        
    type OffreCommerciale =
        | Brouillon of Id: Guid * Libelle: string * Description: string
        | Valide of Id: Guid * Libelle: string * Description: string 