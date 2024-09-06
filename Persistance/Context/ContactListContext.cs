using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class ContactListContext : DbContext
    {
        public ContactListContext(DbContextOptions<ContactListContext> options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.HasIndex(c => c.Email)
                    .IsUnique();

                entity.Property(c => c.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.HasIndex(c => c.PhoneNumber)
                    .IsUnique();
            });
        }
    }
}