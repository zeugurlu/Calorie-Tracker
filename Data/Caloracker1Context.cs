using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Caloracker1.Models;
using Microsoft.AspNetCore.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Caloracker1.Data
{
    public class Caloracker1Context : IdentityDbContext<IdentityUser>
    {
        public Caloracker1Context(DbContextOptions<Caloracker1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CalorackerUser>()
           .HasOne(a => a.Tracks)
           .WithOne(b => b.CalorackerUser)
           .HasForeignKey<Track>(b => b.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.CalorackerUser)
                .WithOne(u => u.Tracks)
                .HasForeignKey<Track>(t => t.UserId)
                .HasPrincipalKey<CalorackerUser>(u => u.Id);

            modelBuilder.Entity<CommentsOfRecipe>()
            .HasOne(c => c.CalorackerUser)
            .WithMany(u => u.CommentsOfRecipes)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CommentsOfRecipe>()
                .HasOne(c => c.Recipe)
                .WithMany(r => r.CommentsOfRecipes)
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);



        }


        public DbSet<Caloracker1.Models.Meal> Meal { get; set; } = default!;
        public DbSet<CalorackerUser> CalorackerUsers { get; set; } = default!;
        public DbSet<Caloracker1.Models.Deneme> Deneme { get; set; } = default!;
        public DbSet<Caloracker1.Models.Recipe> Recipe { get; set; } = default!;
        public DbSet<Caloracker1.Models.Track> Track { get; set; } = default!;
        public DbSet<Caloracker1.Models.Comment> Comment { get; set; } = default!;
        public DbSet<Caloracker1.Models.CreditCard> CreditCard { get; set; } = default!;
        public DbSet<Caloracker1.Models.CommentsOfRecipe> CommentsOfRecipe { get; set; } = default!;
        public override int SaveChanges()
        {
           
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added && entry.Entity is CalorackerUser)
                {
                    var user = (CalorackerUser)entry.Entity;

                    // Create a corresponding Track record
                    var track = new Track
                    {
                        UserId = user.Id,
                        // Set other properties as needed
                    };

                    // Add the Track record to the context
                    Track.Add(track);
                }
            }

            return base.SaveChanges();
        }

    }
}
