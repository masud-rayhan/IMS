using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(ProductCategory))]
        public Guid ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } 

        [ForeignKey(nameof(Brand))]
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public DateTime MfgDate { get; set;}
        public DateTime ExpDate { get; set;}

        public double PerBox { get; set; }

        [ForeignKey(nameof(MeasurementUnit))]
        public Guid MeasurementUnitId { get; set; }
        public MeasurementUnit MeasurementUnit { get; set; }

        public double Size { get; set; }


        [ForeignKey(nameof(Color))]
        public Guid ColorId { get; set; }
        public Color Color { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime Time { get; set; }


        public virtual ICollection<Sell> Sells { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }



    }
}
