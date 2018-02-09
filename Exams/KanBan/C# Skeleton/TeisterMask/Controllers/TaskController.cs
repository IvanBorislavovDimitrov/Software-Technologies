using System;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
            using (var databse = new TeisterMaskDbContext())
            {
                var tasks = databse.Tasks.ToList();
                return View(tasks);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
            return View();

        }

        [HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
            if (ModelState.IsValid)
            {
                using (var database = new TeisterMaskDbContext())
                {
                    database.Tasks.Add(task);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
		[Route("edit/{id}")]
        public ActionResult Edit(int id)
		{
            using (var db = new TeisterMaskDbContext())
            {
                var task = db.Tasks.Where(x => x.Id == id).First();
                return View(task);
            }
        }

        [HttpPost]
		[Route("edit/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int id, Task taskModel)
		{
            using (var database = new TeisterMaskDbContext())
            {
                var taskToEdit = database.Tasks.Find(taskModel.Id); 
                if (taskToEdit != null)
                {
                    taskToEdit.Title = taskModel.Title;
                    taskToEdit.Status = taskModel.Status;
                    database.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }
    }
}