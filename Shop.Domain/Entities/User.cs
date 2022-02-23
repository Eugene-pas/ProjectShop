using Shop.Domain.Entities.Base;

namespace Shop.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Customer Customer { get; set; }

        public Seller Seller { get; set; }

    }
}
