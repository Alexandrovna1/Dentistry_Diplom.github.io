using Dentistry_Diplom.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Dentistry_Diplom.Data.Context
{
    public class DensContext : DbContext
    {
        public DensContext(DbContextOptions<DensContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<DentistryInfo> DentistryTable { get; set; }
        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<ShopDentItem> ShopDentItem { get; set; }
        public DbSet<Order> OrderTable { get; set; }
        public DbSet<OrderDetail> OrderDetailTable { get; set; }
    }
}
