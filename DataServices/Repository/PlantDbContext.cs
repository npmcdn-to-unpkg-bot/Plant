using Interfaces.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace DataServices.Repository
{
    public sealed class PlantDbContext : DbContext, IPlantRepository
    {
        private readonly string _connectionString;
        public PlantDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PlantDbContext(DbContextOptions<ApplicationDbContext> options, string connectionString)
            : base(options)
        {
            _connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddConfiguration(new TreeMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Tree> Trees { get; set; }
    }

    internal class TreeMap : DbEntityConfiguration<Tree>
    {
        public override void Configure(EntityTypeBuilder<Tree> entity)
        {
            entity.ToTable("Trees");
            entity.HasKey(c => c.Id);

            entity.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired();

            entity.HasOne(p=>p.CreatedBy)
                .WithMany(p=>p.Trees)
                .HasForeignKey(p=>p.CreatedByUserId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();

            entity.HasOne(p => p.UpdatedBy)
                .WithMany(p => p.Trees)
                .HasForeignKey(p => p.UpdatedByUserId)
                .HasPrincipalKey(c => c.Id)
                .IsRequired();
        }
    }
}
