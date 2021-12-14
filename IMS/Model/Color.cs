using System;
using System.Collections.Generic;

namespace IMS.Model
{
    public class Color
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RGB { get; set; }

        public virtual ICollection<Color> Colors { get; set; }
    }
}
