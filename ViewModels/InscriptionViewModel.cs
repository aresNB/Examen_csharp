using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace GestionInscriptions.ViewModels
{
    public class InscriptionViewModel
    {
        [Required(ErrorMessage = "La date est requise")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'inscription")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Le montant est requis")]
        [Range(0, double.MaxValue, ErrorMessage = "Le montant doit être positif")]
        [Display(Name = "Montant (FCFA)")]
        public decimal Montant { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner un étudiant")]
        [Display(Name = "Étudiant")]
        public int EtudiantId { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une année scolaire")]
        [Display(Name = "Année Scolaire")]
        public int AnneeScolaireId { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une classe")]
        [Display(Name = "Classe")]
        public int ClasseId { get; set; }

        // Pour les listes déroulantes
        public SelectList? Etudiants { get; set; }
        public SelectList? AnneeScolaires { get; set; }
        public SelectList? Classes { get; set; }
    }
}