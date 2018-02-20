using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class YemekcilerMap : EntityTypeConfiguration<Yemekciler>
    {
        public YemekcilerMap()
        {
            // Primary Key
            this.HasKey(t => t.YemekciID);

            // Properties
            this.Property(t => t.Yemekciler1)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Yemekciler");
            this.Property(t => t.YemekciID).HasColumnName("YemekciID");
            this.Property(t => t.Gun).HasColumnName("Gun");
            this.Property(t => t.Yemekciler1).HasColumnName("Yemekciler");
        }
    }
}
