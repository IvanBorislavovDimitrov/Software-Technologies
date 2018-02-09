namespace ProjectRider.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new ProjectRiderDbContext())
            {
                List<Project> projects = database.Projects.ToList();

                return View(projects);
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
        public ActionResult Create(Project project)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project projectToAdd = new Project();
                projectToAdd.Budget = project.Budget;
                projectToAdd.Description = project.Description;
                projectToAdd.Title = project.Title;
                project.Id = project.Id;

                database.Projects.Add(projectToAdd);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project searchedProject = database.Projects.Find(id);
                if (searchedProject != null)
                {
                    return View(searchedProject);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Project project)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project searchedProject = database.Projects.Find(id);
                if (searchedProject != null)
                {
                    searchedProject.Budget = project.Budget;
                    searchedProject.Description = project.Description;
                    searchedProject.Title = project.Title;
                    database.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project searchedProject = database.Projects.Find(id);
                if (searchedProject != null)
                {
                    return View(searchedProject);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Project reportModel)
        {
            using (var database = new ProjectRiderDbContext())
            {
                Project searchedProject = database.Projects.Find(id);
                if (searchedProject != null)
                {
                    database.Projects.Remove(searchedProject);
                    database.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}