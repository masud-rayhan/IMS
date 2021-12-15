using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public class MeasurementUnit
    {
        public Guid Id { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
