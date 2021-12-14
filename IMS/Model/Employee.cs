using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Model
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }

        [ForeignKey(nameof(Designation))]
        public Guid DesignationId { get; set; }
        public Designation Designation { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}


        public virtual ICollection <Sell> Sells { get; set; }
        public virtual ICollection <Purchase> Purchases { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
