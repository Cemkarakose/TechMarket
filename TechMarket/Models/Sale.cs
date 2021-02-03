using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechMarket.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public DateTime SaleDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer{ get; set; }
    }
}