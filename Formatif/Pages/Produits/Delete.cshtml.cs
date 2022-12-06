using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Formatif.Data;
using Formatif.Models;

namespace Formatif.Pages.Produits
{
    public class DeleteModel : PageModel
    {
        private readonly Formatif.Data.ProduitContext _context;

        public DeleteModel(Formatif.Data.ProduitContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produit Produit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits.FirstOrDefaultAsync(m => m.id == id);

            if (produit == null)
            {
                return NotFound();
            }
            else 
            {
                Produit = produit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }
            var produit = await _context.Produits.FindAsync(id);

            if (produit != null)
            {
                Produit = produit;
                _context.Produits.Remove(Produit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
