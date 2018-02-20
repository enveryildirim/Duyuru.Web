using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class CaycilerMap : EntityTypeConfiguration<Cayciler>
    {
        public CaycilerMap()
        {
            // Primary Key
            this.HasKey(t => t.CayciID);

            // Properties
            this.Property(t => t.Cayci)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Cayciler");
            this.Property(t => t.CayciID).HasColumnName("CayciID");
            this.Property(t => t.Cayci).HasColumnName("Cayci");
            this.Property(t => t.Gun).HasColumnName("Gun");
        }
    }
}
