using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double OpeningBalance { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}
