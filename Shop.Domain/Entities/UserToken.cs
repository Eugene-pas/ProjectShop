using Shop.Domain.Entities.Base;
using System;

namespace Shop.Domain.Entities
{
    public class UserToken : EntityBase
    {
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public User User { get; set; }
    }
}
