namespace DresdenUltimateCasting.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DuccaDbContext : DbContext
    {
        public DuccaDbContext()
            : base("name=DuccaDbContext")
        {
        }

        public DuccaDbContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<ActorImage> ActorImages { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Faction> Factions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

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

            //modelBuilder.Entity<Character>()
            //            .HasMany<Tag>(c => c.Tags)
            //            .WithMany(t => t.Characters)
            //            .Map(ct =>
            //                 {
            //                     ct.MapLeftKey("CharacterId");
            //                     ct.MapRightKey("TagId");
            //                     ct.ToTable("CharacterTags");
            //                 });

            modelBuilder.Entity<Faction>()
                .HasMany(e => e.Characters)
                .WithRequired(e => e.Faction)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Tag>().HasKey(t => t.TagId);
            modelBuilder.Entity<Tag>()
                        .Property(e => e.TagName)
                        .IsUnicode(false);

            //modelBuilder.Entity<Tag>()
            //            .HasMany(e => e.Characters)
            //            .WithMany(e => e.Tags)
            //            .Map(m => m.ToTable("CharacterTags").MapLeftKey("TagId").MapRightKey("CharacterId"));


            modelBuilder.Entity<CharacterTag>()
                        .HasKey(x => new { x.CharacterId, x.TagId });


        }
    }
}
