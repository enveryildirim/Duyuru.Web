using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class YayinAkisiMap : EntityTypeConfiguration<YayinAkisi>
    {
        public YayinAkisiMap()
        {
            // Primary Key
            this.HasKey(t => t.YayinAkisiID);

            // Properties
            // Table & Column Mappings
            this.ToTable("YayinAkisi");
            this.Property(t => t.YayinAkisiID).HasColumnName("YayinAkisiID");
            this.Property(t => t.IcerikID).HasColumnName("IcerikID");
            this.Property(t => t.GosterimSuresi).HasColumnName("GosterimSuresi");
            this.Property(t => t.SonGosterimTarihi).HasColumnName("SonGosterimTarihi");
            this.Property(t => t.GosterimSayisi).HasColumnName("GosterimSayisi");

            // Relationships
            this.HasRequired(t => t.Icerikler)
                .WithMany(t => t.YayinAkisis)
                .HasForeignKey(d => d.IcerikID);

        }
    }
}
