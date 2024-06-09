using Microsoft.EntityFrameworkCore;

namespace Okul.Mvc.Models
{
	public class OkulDbContext : DbContext
	{
        

        public DbSet<Ogrenci> Ogrenciler { get; set; }
		public DbSet<Ders> Ders { get; set; }
        public DbSet<OgrDers> OgrDers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(@"Data Source=.\MSSQLSERVER01;Initial Catalog=OkulDbMvcF;Integrated Security=true;TrustServerCertificate=true");
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ogrenci entity configuration
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("VARCHAR").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("VARCHAR").HasMaxLength(40).IsRequired();

            // Ders entity configuration
            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(d => d.Dersad).HasColumnType("VARCHAR").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.DersKod).HasColumnType("VARCHAR").HasMaxLength(11).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.Kredi).HasColumnType("tinyint").IsRequired();

            // OgrDers entity configuration
            modelBuilder.Entity<OgrDers>().ToTable("tblOgrDers");
            modelBuilder.Entity<OgrDers>().HasKey(od => od.Id); // Primary key
            modelBuilder.Entity<OgrDers>().HasOne(od => od.Ogrenci).WithMany().HasForeignKey(od => od.OgrenciId); // Öğrenci ile ilişki
            modelBuilder.Entity<OgrDers>().HasOne(od => od.Ders).WithMany().HasForeignKey(od => od.DersId); // Ders ile ilişki
        }

    }
}
