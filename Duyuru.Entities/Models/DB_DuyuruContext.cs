using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Duyuru.Entities.Models.Mapping;

namespace Duyuru.Entities.Models
{
    public partial class DB_DuyuruContext : DbContext
    {
        static DB_DuyuruContext()
        {
            Database.SetInitializer<DB_DuyuruContext>(null);
        }

        public DB_DuyuruContext()
            : base("Name=DB_DuyuruContext")
        {
        }

        public DbSet<Cayciler> Caycilers { get; set; }
        public DbSet<Durumlar> Durumlars { get; set; }
        public DbSet<DuyuruInfo> DuyuruInfoes { get; set; }
        public DbSet<Duyurular> Duyurulars { get; set; }
        public DbSet<Icerikler> Iceriklers { get; set; }
        public DbSet<Kantinciler> Kantincilers { get; set; }
        public DbSet<Nobetciler> Nobetcilers { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<YapilacakDuyurular> YapilacakDuyurulars { get; set; }
        public DbSet<YayinAkisi> YayinAkisis { get; set; }
        public DbSet<Yemekciler> Yemekcilers { get; set; }
        public DbSet<Yetkiler> Yetkilers { get; set; }
        public DbSet<Yoneticiler> Yoneticilers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaycilerMap());
            modelBuilder.Configurations.Add(new DurumlarMap());
            modelBuilder.Configurations.Add(new DuyuruInfoMap());
            modelBuilder.Configurations.Add(new DuyurularMap());
            modelBuilder.Configurations.Add(new IceriklerMap());
            modelBuilder.Configurations.Add(new KantincilerMap());
            modelBuilder.Configurations.Add(new NobetcilerMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new YapilacakDuyurularMap());
            modelBuilder.Configurations.Add(new YayinAkisiMap());
            modelBuilder.Configurations.Add(new YemekcilerMap());
            modelBuilder.Configurations.Add(new YetkilerMap());
            modelBuilder.Configurations.Add(new YoneticilerMap());
        }
    }
}
