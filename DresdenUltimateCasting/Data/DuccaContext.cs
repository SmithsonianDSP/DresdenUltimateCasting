using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DresdenUltimateCasting.Database;
using Microsoft.EntityFrameworkCore;

namespace DresdenUltimateCasting.Web.Data
{
    public class DuccaContext : DbContext
    {
        public DuccaContext(DbContextOptions<DuccaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorImage> ActorImages { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Faction> Factions { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorImage>()
                        .Property(e => e.ImageUrl)
                        .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                        .HasMany(e => e.ActorImages)
                        .WithOne(e => e.Actor)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Character>()
                        .HasMany(e => e.Actors)
                        .WithOne(e => e.Character)
                        .OnDelete(DeleteBehavior.NoAction);

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
                        .WithOne(e => e.Faction)
                        .OnDelete(DeleteBehavior.NoAction);


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
