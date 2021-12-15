using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models
{
    public class Sell
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double Paid { get; set; }
        public double Due { get; set; }
        [ForeignKey(nameof(Employee))]
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public DateTime Time { get; set; }

    }
}
