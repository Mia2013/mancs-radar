using mancs_radar_server.Data.Seed;
using mancs_radar_server.Models;
using Microsoft.EntityFrameworkCore;

namespace mancs_radar_server.Data
{
    public class MancsRadarDbContext : DbContext
    {
        public MancsRadarDbContext(DbContextOptions<MancsRadarDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Shelter> Shelters => Set<Shelter>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Dog> Dogs => Set<Dog>();
        public DbSet<DogPhoto> DogPhotos => Set<DogPhoto>();
        public DbSet<DogBreed> DogBreeds => Set<DogBreed>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
              .Property(u => u.Role)
              .HasConversion<string>()
              .HasMaxLength(20);

            modelBuilder.Entity<Shelter>()
                .HasMany(s => s.Users)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ShelterMembers",
                    r => r.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    l => l.HasOne<Shelter>().WithMany().HasForeignKey("ShelterId"));

            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shelter>()
                .HasOne(s => s.Address)
                .WithMany()
                .HasForeignKey(s => s.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DogBreed>(e =>
            {
                e.Property(b => b.Name).HasMaxLength(100);
                e.HasIndex(b => b.Name).IsUnique();
                e.Property(b => b.DogSize).HasConversion<string>().HasMaxLength(20);
                e.HasData(DogBreedSeed.Breeds);
            });

            modelBuilder.Entity<Dog>(e =>
            {
                e.Property(d => d.Sex).HasConversion<string>().HasMaxLength(20);
                e.Property(d => d.ReportType).HasConversion<string>().HasMaxLength(20);
                e.Property(d => d.Status).HasConversion<string>().HasMaxLength(20);
                e.Property(d => d.BreedType).HasConversion<string>().HasMaxLength(20);
                e.Property(d => d.Size).HasConversion<string>().HasMaxLength(20);
                e.Property(d => d.Name).HasMaxLength(100);
                e.Property(d => d.ChipNumber).HasMaxLength(15);

                e.HasIndex(d => d.ChipNumber);
                e.HasIndex(d => new { d.ReportType, d.Status });

                e.HasOne(d => d.ReporterUser)
                    .WithMany()
                    .HasForeignKey(d => d.ReporterUserId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(d => d.ReporterShelter)
                    .WithMany()
                    .HasForeignKey(d => d.ReporterShelterId)
                    .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(d => d.Breed).WithMany().HasForeignKey(d => d.BreedId).OnDelete(DeleteBehavior.Restrict);

                e.ToTable(t => t.HasCheckConstraint(
                    "CK_Dogs_Reporter",
                    "([ReporterUserId] IS NOT NULL AND [ReporterShelterId] IS NULL) OR ([ReporterUserId] IS NULL AND [ReporterShelterId] IS NOT NULL)"));
            });

            modelBuilder.Entity<DogPhoto>(e =>
            {
                e.HasOne(p => p.Dog)
                    .WithMany(d => d.Photos)
                    .HasForeignKey(p => p.DogId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasIndex(p => p.DogId)
                    .IsUnique()
                    .HasFilter("[IsDefault] = 1");
            });

        }
    }
}