using System.Data.Entity.Infrastructure;

namespace DresdenUltimateCasting.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DuccaDbContext : DbContext
    {
        


        public DuccaDbContext()
            : base("name=DuccaDbConnectionString")
        {
        }


        public DuccaDbContext(string connectionString) : base(connectionString)
        {

        }


        public virtual DbSet<ActorImage> ActorImages { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Faction> Factions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorImage>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .HasMany(e => e.ActorImages)
                .WithRequired(e => e.Actor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Character>()
                .HasMany(e => e.Actors)
                .WithRequired(e => e.Character)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faction>()
                .HasMany(e => e.Characters)
                .WithRequired(e => e.Faction)
                .WillCascadeOnDelete(false);
        }
    }



    public class DuccaDbContextFactory : IDbContextFactory<DuccaDbContext>
    {
        const string DbConnectionString = @"data source=(LocalDb)\DUCCADB;initial catalog=DUCCADB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public DuccaDbContext Create()
        {
            return new DuccaDbContext(DbConnectionString);
        }
    }



}
