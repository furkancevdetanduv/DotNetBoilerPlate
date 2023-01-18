using DotNetBoilerPlate.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBoilerPlate.EF
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
