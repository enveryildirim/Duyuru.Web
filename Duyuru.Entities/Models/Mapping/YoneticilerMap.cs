using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Duyuru.Entities.Models.Mapping
{
    public class YoneticilerMap : EntityTypeConfiguration<Yoneticiler>
    {
        public YoneticilerMap()
        {
            // Primary Key
            this.HasKey(t => t.YoneticiID);

            // Properties
            this.Property(t => t.AdSoyad)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Sifre)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Yoneticiler");
            this.Property(t => t.YoneticiID).HasColumnName("YoneticiID");
            this.Property(t => t.AdSoyad).HasColumnName("AdSoyad");
            this.Property(t => t.Sifre).HasColumnName("Sifre");
            this.Property(t => t.LoginMi).HasColumnName("LoginMi");
            this.Property(t => t.YetkiID).HasColumnName("YetkiID");

            // Relationships
            this.HasRequired(t => t.Yetkiler)
                .WithMany(t => t.Yoneticilers)
                .HasForeignKey(d => d.YetkiID);

        }
    }
}
