﻿using System;
using System.Collections.Generic;

namespace IMS.Model
{
    public class Designation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        
    }
}
