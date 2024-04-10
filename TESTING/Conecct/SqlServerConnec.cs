using Microsoft.EntityFrameworkCore;
using TESTING.Models;

namespace TESTING.Conecct
{
    public partial class ModelContext : DbContext
    {
        private static string Cadena = "";

        public ModelContext()
        {
        }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Cadena);
        }

        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TablePermissions(modelBuilder);
            TablePermissionsType(modelBuilder);
            
        }


    }
}
