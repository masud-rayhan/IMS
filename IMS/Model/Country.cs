using System;
using System.Collections.Generic;

namespace IMS.Model
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }

    }
}
