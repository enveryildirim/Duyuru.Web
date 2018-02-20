using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class DurumlarMap : EntityTypeConfiguration<Durumlar>
    {
        public DurumlarMap()
        {
            // Primary Key
            this.HasKey(t => t.Adi);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Durumlar");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Durum).HasColumnName("Durum");
        }
    }
}
