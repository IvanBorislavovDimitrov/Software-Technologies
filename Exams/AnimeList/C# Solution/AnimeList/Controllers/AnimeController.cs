using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AnimeList.Models;

namespace AnimeList.Controllers
{
    [ValidateInput(false)]
    public class AnimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var database = new AnimeListDbContext())
            {
                List<Anime> animes = database.Animes.ToList();
                return View(animes);
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
        public ActionResult Create(Anime anime)
        {
            if (ModelState.IsValid)
            {
                using (var database = new AnimeListDbContext())
                {
                    Anime animeToAdd = new Anime();
                    animeToAdd.Id = anime.Id;
                    animeToAdd.Name = anime.Name;
                    animeToAdd.Rating = anime.Rating;
                    animeToAdd.Watched = anime.Watched;
                    animeToAdd.Description = anime.Description;
                    database.Animes.Add(animeToAdd);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            Anime badAnime = new Anime();
            badAnime.Id = anime.Id;
            badAnime.Name = anime.Name;
            badAnime.Rating = anime.Rating;
            badAnime.Watched = anime.Watched;
            badAnime.Description = anime.Description;

            return View(badAnime);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            using (var database = new AnimeListDbContext())
            {
                Anime searchedAnime = database.Animes.Find(id);
                if (searchedAnime == null)
                {
                    return RedirectToAction("Index");
                }

                return View(searchedAnime);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Anime animeModel)
        {
            using (var database = new AnimeListDbContext())
            {
                Anime searchedAnime = database.Animes.Find(animeModel.Id);
                if (searchedAnime == null)
                {
                    return RedirectToAction("Index");
                }

                database.Animes.Remove(searchedAnime);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}