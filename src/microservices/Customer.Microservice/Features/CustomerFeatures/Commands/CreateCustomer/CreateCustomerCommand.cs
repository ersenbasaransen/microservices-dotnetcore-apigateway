using Customer.Microservice.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Microservice.Features.CustomerFeatures.Commands.CreateProduct
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateCustomerCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var product = new Entities.Customer();
                product.Name = command.Name;
                product.Email = command.Email;
                product.City = command.City;
                product.Contact = command.Contact;
                _context.Customers.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
