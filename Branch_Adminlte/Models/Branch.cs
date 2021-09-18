using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Branch_Adminlte.Models
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

    }
}