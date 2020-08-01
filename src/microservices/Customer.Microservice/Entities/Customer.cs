namespace Customer.Microservice.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
