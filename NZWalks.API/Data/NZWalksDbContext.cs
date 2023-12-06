using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext:DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) 
        {
            
        }

        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }
        public DbSet<Walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulties
            //easy,hard and Medium

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("cd6666fd-6d2f-4a1b-a2c3-8bc1ca0e74c1"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("05abb55d-3f75-471a-8f05-c8e8c506f15d"),
                    Name="Medium"

                },
                new Difficulty() {
                Id=Guid.Parse("ceb67693-65ed-4975-be6d-3755069ad11b"),
                Name="Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("fb7aec7f-d049-497a-abe4-5616afccfd47"),
                    Name="Hyderabad",
                    Code="hyd",
                    RegionImageURL="SOme-image.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("d450126e-1ed2-4e9c-801d-bfd0d51be7c2"),
                    Name="Bangalore",
                    Code="Bng",
                    RegionImageURL="Bangalore-image.jpg"
                },
                new Region()
                {
                    Id=Guid.Parse("c0ece3dd-d65a-4d74-ad1b-b83f2e46cc30"),
                    Name="Penturu",
                    Code="Ptr",
                    RegionImageURL="Penturu-Image.png"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
