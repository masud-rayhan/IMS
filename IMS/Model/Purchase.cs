using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Model
{
    public class Purchase
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Tax { get; set; }
        public double ShppingCost { get; set; }
        public double OtherCost { get; set; }
        public double TotalCost { get; set; }
        public double CostPerProduct { get; set; }
        public double paid { get; set; }
        public double Due { get; set; }
        public string ChallanNumber { get; set; }

        [ForeignKey(nameof(Supplier))]
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        
        [ForeignKey(nameof(Employee))]
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string Status { get; set; }
        public string Remark { get; set; }
        public DateTime Time { get; set; }





    }
}
