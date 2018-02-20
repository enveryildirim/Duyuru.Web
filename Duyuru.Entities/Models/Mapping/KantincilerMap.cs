using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class KantincilerMap : EntityTypeConfiguration<Kantinciler>
    {
        public KantincilerMap()
        {
            // Primary Key
            this.HasKey(t => t.KantinciID);

            // Properties
            this.Property(t => t.KantinciID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Kantinci)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Kantinciler");
            this.Property(t => t.KantinciID).HasColumnName("KantinciID");
            this.Property(t => t.Kantinci).HasColumnName("Kantinci");
            this.Property(t => t.Gun).HasColumnName("Gun");
        }
    }
}
