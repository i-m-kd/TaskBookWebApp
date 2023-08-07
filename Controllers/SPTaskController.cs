using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskBookWebApp.Areas.Identity.Data;
using TaskBookWebApp.Models;

namespace TaskBookWebApp.Controllers
{
    public class SPTaskController : Controller
    {
        private readonly ConnectionHelper _connectionHelper;
        private readonly UserManager<TaskBookWebAppUser> _userManager;

        public SPTaskController(ConnectionHelper connectionHelper, UserManager<TaskBookWebAppUser> userManager)
        {
            _connectionHelper = connectionHelper;
            _userManager = userManager;
        }

        public IActionResult TaskIndex()
        {
            return ViewTask();
        }
        public IActionResult TaskSuccess()
        {
            return ViewTask();
        }
        public IActionResult TaskError()
        {
            return ViewTask();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            string userId = _userManager.GetUserId(User);
            var taskModel = new TaskModel();
            taskModel.UserId = userId;
            return View(taskModel);
        }
        #region InsertData
        [HttpPost]
        public IActionResult AddTask(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                _connectionHelper.Add(task,userId);
                return View("Success");
            }

            return View(task);
        }
        #endregion

        public IActionResult ViewTask()
        {
            string userId = _userManager.GetUserId(User);
            List<TaskModel> tasks = _connectionHelper.View(userId);
            return View(tasks);
        }

        public IActionResult UpdateTask(int id)
        {
            string userId = _userManager.GetUserId(User);

            TaskModel Update = _connectionHelper.View(userId).FirstOrDefault(task => task.Id == id);

            if (Update == null)
            {
                return NotFound();
            }

            return View("UpdateTask", Update);
        }

        [HttpPost]
        public IActionResult UpdateTask(TaskModel updatedTask)
        {
            if (ModelState.IsValid)
            {
                _connectionHelper.Update(updatedTask);
                return RedirectToAction("ViewTask");
            }

            return View(updatedTask);
        }
        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            string userId = _userManager.GetUserId(User);

            TaskModel Delete = _connectionHelper.View(userId).FirstOrDefault(task => task.Id == id);

            if (Delete == null)
            {
                return NotFound();
            }

            return View(Delete);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            _connectionHelper.Delete(id);

            return RedirectToAction(nameof(ViewTask));
        }

    }
}
