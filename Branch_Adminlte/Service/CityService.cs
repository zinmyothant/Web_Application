using Branch_Adminlte.Models;
using Branch_Adminlte.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Branch_Adminlte.Service
{
    public class CityService
    {
        private readonly BranchDbContext _context = new BranchDbContext();
        public List<CityViewModel> GetAllCity()
        {
            List<CityViewModel> cities = _context.Cities
                .Select(s => new CityViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
            return cities;
        }

        public CityViewModel GetCityById(Guid id)
        {
            CityViewModel city = _context.Cities
                .Where(s => s.Id == id)
                .Select(s => new CityViewModel
                {
                    Id = s.Id,
                    Name = s.Name

                }).FirstOrDefault();

            return city;
        }
        }
    
}