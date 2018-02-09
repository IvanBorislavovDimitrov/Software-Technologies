using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new IMDBDbContext())
            {
                var films = database.Films.ToList();

                return View(films);
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
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                using (var database = new IMDBDbContext())
                {
                    database.Films.Add(film);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(film);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new IMDBDbContext())
            {
                var film = database.Films.Where(x => x.Id == id).First();

                if (film == null)
                {
                    return HttpNotFound();
                }

                var model = new Film();
                model.Id = film.Id;
                model.Director = film.Director;
                model.Genre = film.Genre;
                model.Name = film.Name;
                model.Year = film.Year;

                return View(model);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (ModelState.IsValid)
            {
                using (var database = new IMDBDbContext())
                {
                    var film = database.Films.FirstOrDefault(a => a.Id == filmModel.Id);
                    film.Director = filmModel.Director;
                    film.Genre = filmModel.Genre;
                    film.Year = filmModel.Year;
                    film.Name = filmModel.Name;

                    database.Entry(film).State = System.Data.Entity.EntityState.Modified;
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(filmModel);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new IMDBDbContext())
            {
                var film = database.Films.Where(x => x.Id == id).First();
                
                if (film == null)
                {
                    return HttpNotFound();
                }

                return View(film);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new IMDBDbContext())
            {
                var film = database.Films.Where(a => a.Id == filmModel.Id).First();

                if (film == null)
                {
                    return HttpNotFound();
                }

                database.Films.Remove(film);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}