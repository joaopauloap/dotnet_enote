using eshop.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata;
using System.Xml;

namespace eshop.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }


        // Entidades.
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(c => c.User)
                .WithMany(a => a.Notes)
                .HasForeignKey(a => a.UserId);
        }
    }
}
