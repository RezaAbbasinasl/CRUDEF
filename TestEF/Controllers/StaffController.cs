using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEF.Models;

namespace TestEF.Controllers
{
    public class StaffController : Controller
    {
        private readonly BikeStoreContext _dbContext;

        public StaffController(BikeStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var staffs =  await _dbContext.Staffs.ToListAsync();
            return View(staffs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            _dbContext.Staffs.Add(staff);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public Staff GetById(int id)
        {
            var staff = _dbContext.Staffs.Where(x =>x.StaffId == id).FirstOrDefault();
            return staff;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int storeId)
        {
            var staff = GetById(storeId);
            return View(staff);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Staff staff)
        {
            _dbContext.Staffs.Update(staff);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _dbContext.Staffs.Remove(GetById(id));
            _dbContext.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var staff = GetById(id);
            return View(staff);
        }
    }
}
