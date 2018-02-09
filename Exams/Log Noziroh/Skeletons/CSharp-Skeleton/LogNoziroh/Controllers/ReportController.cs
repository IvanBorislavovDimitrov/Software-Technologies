namespace LogNoziroh.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    [ValidateInput(false)]
    public class ReportController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new LogNozirohDbContext())
            {
                var reports = database.Reports.ToList();
                return View(reports);
            }
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            using (var database = new LogNozirohDbContext())
            {
                var report = database.Reports.Find(id);
                if (report != null)
                {
                    return View(report);
                }
            }

            return RedirectToAction("Index");
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
        public ActionResult Create(Report report)
        {
             if (ModelState.IsValid)
            {
                using (var database = new LogNozirohDbContext())
                {
                    Report newReport = new Report();
                    newReport.Id = report.Id;
                    newReport.Message = report.Message;
                    newReport.Origin = report.Origin;
                    newReport.Status = report.Status;

                    database.Reports.Add(newReport);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Create");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var database = new LogNozirohDbContext())
            {
                var report = database.Reports.Find(id);
                if (report != null)
                {
                    return View(report);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Report reportModel)
        {
            using (var database = new LogNozirohDbContext())
            {
                var report = database.Reports.Find(id);
                if (report != null)
                {
                    database.Reports.Remove(report);
                    database.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}