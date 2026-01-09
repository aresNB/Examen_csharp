using Microsoft.EntityFrameworkCore;
using GestionInscriptions.Models;

namespace GestionInscriptions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Classe> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations
            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Etudiant)
                .WithMany(e => e.Inscriptions)
                .HasForeignKey(i => i.EtudiantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.AnneeScolaire)
                .WithMany(a => a.Inscriptions)
                .HasForeignKey(i => i.AnneeScolaireId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Classe)
                .WithMany(c => c.Inscriptions)
                .HasForeignKey(i => i.ClasseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Données de test
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Années scolaires
            modelBuilder.Entity<AnneeScolaire>().HasData(
                new AnneeScolaire { Id = 1, Code = "2024-2025", Libelle = "Année 2024-2025", Statut = Statut.EnCours },
                new AnneeScolaire { Id = 2, Code = "2023-2024", Libelle = "Année 2023-2024", Statut = Statut.Cloture }
            );

            // Classes
            modelBuilder.Entity<Classe>().HasData(
                new Classe { Id = 1, Code = "L1", Libelle = "Licence 1" },
                new Classe { Id = 2, Code = "L2", Libelle = "Licence 2" },
                new Classe { Id = 3, Code = "L3", Libelle = "Licence 3" }
            );

            // Étudiants
            modelBuilder.Entity<Etudiant>().HasData(
                new Etudiant { Id = 1, Nom = "Diallo", Prenom = "Mamadou", Matricule = "ETU001" },
                new Etudiant { Id = 2, Nom = "Traoré", Prenom = "Fatou", Matricule = "ETU002" },
                new Etudiant { Id = 3, Nom = "Sow", Prenom = "Aminata", Matricule = "ETU003" }
            );
        }
    }
}