using Formatif.Models;
using Microsoft.EntityFrameworkCore;

namespace Formatif.Data
{
    public class ProduitContext : DbContext
    {
        public ProduitContext(DbContextOptions<ProduitContext> options) : base(options) { 
        
        }
        public DbSet<Produit> Produits { get; set; } = default !;
    }
}
