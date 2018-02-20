using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class YapilacakDuyurularMap : EntityTypeConfiguration<YapilacakDuyurular>
    {
        public YapilacakDuyurularMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("YapilacakDuyurular");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.DuyuruID).HasColumnName("DuyuruID");

            // Relationships
            this.HasRequired(t => t.DuyuruInfo)
                .WithMany(t => t.YapilacakDuyurulars)
                .HasForeignKey(d => d.DuyuruID);

        }
    }
}
