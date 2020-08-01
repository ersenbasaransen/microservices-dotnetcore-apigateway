using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace Product.Microservice.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("products");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}