using Huginn.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Huginn.Database;

public class HuginnDbContext(DbContextOptions<HuginnDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}
