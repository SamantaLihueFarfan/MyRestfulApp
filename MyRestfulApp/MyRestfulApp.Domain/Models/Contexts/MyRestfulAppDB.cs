namespace MyRestfulApp.Domain.Models.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp;

    public class MyRestfulAppDB : DbContext
    {
        public MyRestfulAppDB(DbContextOptions<MyRestfulAppDB> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer((sqlServerOptions => sqlServerOptions.CommandTimeout(600)));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                return;
            }

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }

        public DbSet<User> Users { get; set; }
    }
}
