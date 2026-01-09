using System;
using System.ComponentModel.DataAnnotations;

namespace GestionInscriptions.Models
{
    public class Inscription
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La date est requise")]
        [DataType(DataType.Date)]
        [Display(Name = "Date d'inscription")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Le montant est requis")]
        [Range(0, double.MaxValue, ErrorMessage = "Le montant doit être positif")]
        [Display(Name = "Montant")]
        public decimal Montant { get; set; }

        // Foreign Keys
        [Required(ErrorMessage = "L'étudiant est requis")]
        public int EtudiantId { get; set; }

        [Required(ErrorMessage = "L'année scolaire est requise")]
        public int AnneeScolaireId { get; set; }

        [Required(ErrorMessage = "La classe est requise")]
        public int ClasseId { get; set; }

        // Navigation properties
        public Etudiant Etudiant { get; set; } = null!;
        public AnneeScolaire AnneeScolaire { get; set; } = null!;
        public Classe Classe { get; set; } = null!;
    }
}