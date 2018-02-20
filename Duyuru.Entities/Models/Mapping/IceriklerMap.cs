using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class IceriklerMap : EntityTypeConfiguration<Icerikler>
    {
        public IceriklerMap()
        {
            // Primary Key
            this.HasKey(t => t.IcerikID);

            // Properties
            this.Property(t => t.Baslik)
                .HasMaxLength(50);

            this.Property(t => t.IcerikURL)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Icerikler");
            this.Property(t => t.IcerikID).HasColumnName("IcerikID");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.IcerikURL).HasColumnName("IcerikURL");
            this.Property(t => t.EkleyenID).HasColumnName("EkleyenID");

            // Relationships
            this.HasRequired(t => t.Yoneticiler)
                .WithMany(t => t.Iceriklers)
                .HasForeignKey(d => d.EkleyenID);

        }
    }
}
