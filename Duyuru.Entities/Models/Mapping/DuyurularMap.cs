using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class DuyurularMap : EntityTypeConfiguration<Duyurular>
    {
        public DuyurularMap()
        {
            // Primary Key
            this.HasKey(t => t.DuyuruID);

            // Properties
            this.Property(t => t.Duyuru)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Duyurular");
            this.Property(t => t.DuyuruID).HasColumnName("DuyuruID");
            this.Property(t => t.Duyuru).HasColumnName("Duyuru");
            this.Property(t => t.SonGosterim).HasColumnName("SonGosterim");
        }
    }
}
