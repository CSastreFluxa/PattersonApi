using Microsoft.EntityFrameworkCore;
using Patterson.Domain.Entities;

namespace Patterson.Domain.Interfaces
{
    public interface IUserDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Form> Forms { get; set; }
        DbSet<FormField> FormFields { get; set; }
        DbSet<Field> Fields { get; set; }
    }
}