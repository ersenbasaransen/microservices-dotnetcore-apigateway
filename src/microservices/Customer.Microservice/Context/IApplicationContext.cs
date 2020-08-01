using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Context
{
    public interface IApplicationContext
    {
        DbSet<Entities.Customer> Customers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}