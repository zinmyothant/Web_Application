using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Branch_Adminlte.ViewModel
{
    public class BranchViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DisplayName("City Name")]
        public Guid CityId { get; set; }
        [DisplayName("City Name")]
        public string CityName { get; set; }
        public List<CityViewModel> City { get; set; } = new List<CityViewModel>();
        public string Address { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}