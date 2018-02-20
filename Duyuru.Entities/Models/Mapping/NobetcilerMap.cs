using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class NobetcilerMap : EntityTypeConfiguration<Nobetciler>
    {
        public NobetcilerMap()
        {
            // Primary Key
            this.HasKey(t => t.NobetciID);

            // Properties
            this.Property(t => t.Nobetci)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Nobetciler");
            this.Property(t => t.NobetciID).HasColumnName("NobetciID");
            this.Property(t => t.Nobetci).HasColumnName("Nobetci");
            this.Property(t => t.Gun).HasColumnName("Gun");
            this.Property(t => t.Saat).HasColumnName("Saat");
        }
    }
}
