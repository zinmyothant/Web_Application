using Branch_Adminlte.Models;
using Branch_Adminlte.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Branch_Adminlte.Service
{
    public class BranchService
    {
        private readonly BranchDbContext _context = new BranchDbContext();
        public List<BranchViewModel> GetAllBranch()
        {
            //read all branch

            List<BranchViewModel> branches = _context.Branches.Join(
                _context.Cities,
                b => b.CityId,
                c => c.Id,
                (b, c) => new { b, c }
                ).Select(bc => new BranchViewModel
                {
                    Id = bc.b.Id,
                    Name = bc.b.Name,
                    CityId = bc.b.CityId,
                    CityName = bc.c.Name,
                    Address = bc.b.Address,
                    Email = bc.b.Email,
                    Note = bc.b.Note

                }).ToList();              

                
            return branches;
           
        }
        //read by id
        public BranchViewModel GetBranchById(Guid id)
        {
            BranchViewModel branch = _context.Branches.Where(s => s.Id == id)
                .Select(s => new BranchViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CityName = s.CityName,
                    CityId = s.CityId,
                    Address = s.Address,
                    Email = s.Email,
                    Note = s.Note
                }).FirstOrDefault();
            return branch;
        }
        //new branch create
        public void Create(BranchViewModel viewModel)
        {
            Branch entity = new Branch();
            entity.Id = Guid.NewGuid();
            entity.Name = viewModel.Name;
            entity.CityId = viewModel.CityId;
            entity.CityName = viewModel.CityName;
            entity.Address = viewModel.Address;
            entity.Email = viewModel.Email;
            entity.Note = viewModel.Note;
            _context.Branches.Add(entity);
            _context.SaveChanges();
        }
        //edit
        public void Update(BranchViewModel viewModel)
        {
            Branch entity = _context.Branches.Where(s => s.Id == viewModel.Id)
                .Select(s => s).FirstOrDefault();
            if (entity != null)
            {
                entity.Id = viewModel.Id;
                entity.Name = viewModel.Name;
                entity.CityId = viewModel.CityId;
                entity.CityName = viewModel.CityName;
                entity.Address = viewModel.Address;
                entity.Email = viewModel.Email;
                entity.Note = viewModel.Note;
                _context.SaveChanges();
            }
            
        }
        //delete
        public void Delete(Guid id)
        {
            Branch entity = _context.Branches.Where(s => s.Id == id)
                .Select(s => s).FirstOrDefault();
            if (entity != null)
            {
                _context.Branches.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}