using Customer.Microservice.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.CustomerFeatures.Queries.GetProduct
{
    public class GetCustomerByIdQuery : IRequest<Entities.Customer>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Entities.Customer>
        {
            private readonly IApplicationContext _context;
            public GetCustomerByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<Entities.Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (customer == null) return null;
                return customer;
            }
        }
    }
}
