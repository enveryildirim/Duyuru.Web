using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class DuyuruInfoMap : EntityTypeConfiguration<DuyuruInfo>
    {
        public DuyuruInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.DuyuruID);

            // Properties
            this.Property(t => t.DuyuruAdi)
                .HasMaxLength(50);

            this.Property(t => t.DuyuruAdresi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DuyuruInfo");
            this.Property(t => t.DuyuruID).HasColumnName("DuyuruID");
            this.Property(t => t.DuyuruAdi).HasColumnName("DuyuruAdi");
            this.Property(t => t.DuyuruAdresi).HasColumnName("DuyuruAdresi");
        }
    }
}
