namespace LogNoziroh.App.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class ReportController : Controller
    {
        private readonly LogNozirohDbContext context;

        public ReportController(LogNozirohDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            //TODO: Implement me ...
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            //TODO: Implement me ...
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            //TODO: Implement me ...
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Report report)
        {
            //TODO: Implement me ...
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            //TODO: Implement me ...
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Report reportModel)
        {
            //TODO: Implement me ...
        }
    }
}