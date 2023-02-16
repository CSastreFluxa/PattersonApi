using Microsoft.EntityFrameworkCore;
using Patterson.Domain.Entities;
using Patterson.Domain.Interfaces;
using System.Threading.Tasks;

namespace Patterson.Infrastructure.Persistence
{
    public class UserDbContext : DbContext, IUserDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<Field> Fields { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Forms)
                .WithOne()
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Form>()
                .HasMany(f => f.FormFields)
                .WithOne()
                .HasForeignKey(ff => ff.FormId);

            modelBuilder.Entity<FormField>()
                .HasOne(ff => ff.Field)
                .WithMany()
                .HasForeignKey(ff => ff.FieldId);
        }
    }
}