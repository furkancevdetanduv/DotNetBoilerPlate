using DotNetBoilerPlate.EF.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerPlate.EF
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
