using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Model
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }
        public Country  Country { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
