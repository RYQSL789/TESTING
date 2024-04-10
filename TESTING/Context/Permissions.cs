using Microsoft.EntityFrameworkCore;
using TESTING.Models;

namespace TESTING.Conecct
{
    public partial class ModelContext : DbContext
    {
        private void TablePermissions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("Permissions");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .IsRequired()
                    ;

                entity.Property(e => e.PermissonType)
                   .HasColumnName("PermissonType")
                   .IsRequired()
                   ;

                entity.Property(e => e.EmployeeForceName)
                    .HasColumnName("EmployeeForceName")
                    .HasMaxLength(100)
                    ;

                entity.Property(e => e.EmployeeSuname)
                   .HasColumnName("EmployeeSuname")
                   .HasMaxLength(100)
                   ;

                entity.Property(e => e.Description)
                   .HasColumnName("Description")
                   .HasMaxLength(100)
                   ;

                entity.Property(e => e.PermissionDate)
                  .HasColumnName("PermissionDate")
                  .HasMaxLength(100)
                  ;


            });
        }
    }
}
