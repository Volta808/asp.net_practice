using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Formatif.Data;
using Formatif.Models;

namespace Formatif.Pages.Produits
{
    public class CreateModel : PageModel
    {
        private readonly Formatif.Data.ProduitContext _context;

        public CreateModel(Formatif.Data.ProduitContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
