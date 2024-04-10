using Microsoft.EntityFrameworkCore;
using TESTING.Models;

namespace TESTING.Conecct
{
    public partial class ModelContext : DbContext
    {
        private void TablePermissionsType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionTypes>(entity =>
            {
                entity.ToTable("PermissionTypes");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    ;

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(100)
                    ;
            });
        }
    }
}
