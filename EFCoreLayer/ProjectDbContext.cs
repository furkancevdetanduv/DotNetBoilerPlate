using EFCoreLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreLayer
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        }

        public DbSet<TestModel> testModels { get; set; }
    }
}
