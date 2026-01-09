using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInscriptions.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prénom est requis")]
        [StringLength(100)]
        public string Prenom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le matricule est requis")]
        [StringLength(50)]
        public string Matricule { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
    }
}