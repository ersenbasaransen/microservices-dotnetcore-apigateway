using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Configurations
{
    public class CustomerConfiguration
    {
        public void Configure(EntityTypeBuilder<Entities.Customer> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Email)
                .IsRequired();
        }
    }
}
