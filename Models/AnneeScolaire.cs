using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInscriptions.Models
{
    public class AnneeScolaire
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Libelle { get; set; } = string.Empty;

        public Statut Statut { get; set; }

        // Navigation property
        public ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
    }
}