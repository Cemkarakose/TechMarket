using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechMarket.Models
{
    public class Customer : Person
    {
        
        public DateTime Birthday { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}