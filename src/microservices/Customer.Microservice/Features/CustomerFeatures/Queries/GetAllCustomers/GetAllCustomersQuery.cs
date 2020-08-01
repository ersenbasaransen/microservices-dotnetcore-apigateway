using Customer.Microservice.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.CustomerFeatures.Queries.GetAllProducts
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Entities.Customer>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Entities.Customer>>
        {
            private readonly IApplicationContext _context;
            public GetAllCustomersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Entities.Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                var customerList = await _context.Customers.ToListAsync();
                if (customerList == null)
                {
                    return null;
                }
                return customerList.AsReadOnly();
            }
        }
    }
}
