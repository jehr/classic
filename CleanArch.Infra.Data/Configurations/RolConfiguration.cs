using Domain.Models.Rol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(150);

            builder.Property(x => x.DisplayName)
                 .HasMaxLength(100);
        }
    }
}
