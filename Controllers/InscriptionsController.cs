using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionInscriptions.Data;
using GestionInscriptions.Models;
using GestionInscriptions.ViewModels;
using System.Threading.Tasks;
using System.Linq;

namespace GestionInscriptions.Controllers
{
    public class InscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            var inscriptions = await _context.Inscriptions
                .Include(i => i.Etudiant)
                .Include(i => i.AnneeScolaire)
                .Include(i => i.Classe)
                .OrderByDescending(i => i.Date)
                .ToListAsync();

            return View(inscriptions);
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            var viewModel = new InscriptionViewModel
            {
                Date = DateTime.Now,
                Etudiants = new SelectList(_context.Etudiants, "Id", "Matricule"),
                AnneeScolaires = new SelectList(_context.AnneeScolaires.Where(a => a.Statut == Statut.EnCours), "Id", "Libelle"),
                Classes = new SelectList(_context.Classes, "Id", "Libelle")
            };

            return View(viewModel);
        }

        // POST: Inscriptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InscriptionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var inscription = new Inscription
                {
                    Date = viewModel.Date,
                    Montant = viewModel.Montant,
                    EtudiantId = viewModel.EtudiantId,
                    AnneeScolaireId = viewModel.AnneeScolaireId,
                    ClasseId = viewModel.ClasseId
                };

                _context.Add(inscription);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Inscription enregistrée avec succès !";
                return RedirectToAction(nameof(Index));
            }

            // Recharger les listes en cas d'erreur
            viewModel.Etudiants = new SelectList(_context.Etudiants, "Id", "Matricule", viewModel.EtudiantId);
            viewModel.AnneeScolaires = new SelectList(_context.AnneeScolaires.Where(a => a.Statut == Statut.EnCours), "Id", "Libelle", viewModel.AnneeScolaireId);
            viewModel.Classes = new SelectList(_context.Classes, "Id", "Libelle", viewModel.ClasseId);

            return View(viewModel);
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscriptions
                .Include(i => i.Etudiant)
                .Include(i => i.AnneeScolaire)
                .Include(i => i.Classe)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }
    }
}