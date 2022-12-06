using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Formatif.Data;
using Formatif.Models;

namespace Formatif.Pages
{
    public class IndexProduitsModel : PageModel
    {
        private readonly Formatif.Data.ProduitContext _context;

        public IndexProduitsModel(Formatif.Data.ProduitContext context)
        {
            _context = context;
        }

        public IList<Produit> Produit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Produits != null)
            {
                Produit = await _context.Produits.ToListAsync();
            }
        }
    }
}
