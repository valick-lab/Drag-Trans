using DragTrans.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DragTrans.Infrastructure.Data;

public class DragTransDbContext : DbContext
{
    public DragTransDbContext(
        DbContextOptions<DragTransDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}