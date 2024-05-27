﻿namespace ElasticDotnet.Domain.Models;

public record ProductResponse(
    string CodeInterne, 
    string ImageProduit,
    string CodeABarre,
    string REFERENCE,
    string SKU,
    string LabelProduit,
    string SEOLabelProduit,
    string Categorie,
    string SousCategorie,
    string SousSousCategorie,
    int CategorieId,
    string Collection,
    string BreveDescription,
    string Description,
    string Tags,
    string FicheTechnique,
    string AltImage,
    string Link,
    string MetaDescription,
    string MetaTitle,
    string OldOptimizationGrade,
    string NewOptimizationGrade,
    float Poids,
    string Couleur,
    int? ColorId,
    string Marque,
    int MarqueId,
    string Garantie,
    float Stock,
    string FabriqueEn,
    string EstRetournable,
    float PrixVendeur,
    float PrixBrute,
    float PrixPromo,
    string LienWebEtVideo,
    string ImagePrincipale,
    string ImagesSecondaires,
    string SellerId,
    string CreatedBy
);