using Branch_Adminlte.Service;
using Branch_Adminlte.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Branch_Adminlte.Controllers
{
    public class BranchController : Controller
    {
        private readonly BranchService _branchService = new BranchService();
        private readonly CityService _cityService = new CityService();
        // GET: Branch
        public ActionResult Index()
        {
            List<BranchViewModel> list = _branchService.GetAllBranch();
            return View(list);
        }
        //create
        public ActionResult Create()
        {
            BranchViewModel newViewModel = new BranchViewModel();
            newViewModel.City = _cityService.GetAllCity();
            return View(newViewModel);
        }
        [HttpPost]
        public ActionResult Create(BranchViewModel viewModel)
        {
            _branchService.Create(viewModel);
            return RedirectToAction("index");
        }
        public ActionResult Edit(Guid id)
        {
            BranchViewModel entity = _branchService.GetBranchById(id);
            entity.City = _cityService.GetAllCity();
            return View(entity);
        }
        [HttpPost]
        public ActionResult Edit(BranchViewModel viewModel)
        {
            _branchService.Update(viewModel);
            return RedirectToAction("index");
        }
        //delete
        public ActionResult Delete(Guid id)
        {
            _branchService.Delete(id);
            return RedirectToAction("index");
        }
        public ActionResult ReportDatailReport()
        {
            List<BranchViewModel> list = _branchService.GetAllBranch();
            Session["ReportData"] = list;
            return View();
        }
    }
}