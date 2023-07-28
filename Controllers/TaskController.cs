using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBookWebApp.Data;
using TaskBookWebApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TaskBookWebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskBookDbContext _dbContext;

        public TaskController(TaskBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult StoreData()
        {
            return View();
        }

        public IActionResult Success() => View();

        public async Task<IActionResult> ViewData()
        {
            var taskDataList = await _dbContext.Tasks.ToListAsync();
            return View(taskDataList);
        }

        [HttpPost]
        public async Task<IActionResult> StoreData(TaskData model)
        {
            if (ModelState.IsValid)
            {
                model.Date = model.Date.Date;
                _dbContext.Tasks.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Success");
            }
            return View("StoreData", model);
        }

        public async Task<IActionResult> EditData(int id)
        {
            var taskData = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
            if (taskData == null)
                return NotFound();
            return View(taskData);
        }

        [HttpPost]
        public async Task<IActionResult> EditData(int id, TaskData model)
        {
            if (id != model.TaskId)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Tasks.Update(model);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Success");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDataExists(id))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(model);
        }

        private bool TaskDataExists(int id)
        {
            return _dbContext.Tasks.Any(t => t.TaskId == id);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteData(int? id)
        {
            if (id == null)
                return NotFound();
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDataConfirmed(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ViewData");
        }
    }
}
