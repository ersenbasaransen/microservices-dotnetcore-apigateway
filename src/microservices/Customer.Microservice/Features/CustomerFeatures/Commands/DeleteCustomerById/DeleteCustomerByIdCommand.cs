using Customer.Microservice.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.CustomerFeatures.Commands.DeleteProductById
{
    public class DeleteCustomerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteCustomerByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Customers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (product == null) return default;
                _context.Customers.Remove(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
