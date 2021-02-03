using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechMarket.Models
{
    public class Admin : Person
    {
        public DateTime HireDate { get; set; }
        public string Localization { get; set; }
    }
}