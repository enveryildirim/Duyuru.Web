using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class YetkilerMap : EntityTypeConfiguration<Yetkiler>
    {
        public YetkilerMap()
        {
            // Primary Key
            this.HasKey(t => t.YetkiID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Yetkiler");
            this.Property(t => t.YetkiID).HasColumnName("YetkiID");
            this.Property(t => t.Adi).HasColumnName("Adi");
        }
    }
}
