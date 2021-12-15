using System;
using System.Collections.Generic;

namespace IMS.Models
{
    public class Color
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RGB { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
