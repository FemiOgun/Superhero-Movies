using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.SHC.Models;
using Web.SHC.Repository;

namespace Web.SHC.Controllers
{
    public class SuperHeroesController : Controller
    {
        // GET: SuperHeroes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CharatcterList()
        {
            List<Character> characters = new List<Character>();
            characters = CharacterRepository.List();
            return View(characters);
        }
        public ActionResult CharacterEdit(int characterID = 0)
        {
            ViewModelCharacterMovie viewModelCharacterMovie = new ViewModelCharacterMovie();
            viewModelCharacterMovie.Movies = MoviesRepository.List();

            if (characterID > 0)
            {
                viewModelCharacterMovie.Character = CharacterRepository.Read(characterID);
                ViewData["Image"] = "true";
                return View(viewModelCharacterMovie);
            }
            return View(viewModelCharacterMovie);
        }
        [HttpPost]
        public ActionResult CharacterEdit(HttpPostedFileBase Image, Character character)
        {
            if (Image != null)
            {
                character.Image = UploadImage(Image, character.Image);
            }
            if (character.CharacterID > 0) CharacterRepository.Update(character);
            else CharacterRepository.Insert(character);
            return RedirectToAction("CharatcterList");
        }
        public ActionResult CharacterDetail(int CharacterID)
        {
            Character character = new Character();
            character = CharacterRepository.Read(CharacterID);
            return View(character);
        }
        public ActionResult CharacterDelete(int characterID, string imageAddress)
        {
            string Paath = Server.MapPath("~/Images/");

            imageAddress = imageAddress.Substring(imageAddress.IndexOf("/"));
            FileInfo path = new FileInfo(Paath + imageAddress);
            path.Delete();

            CharacterRepository.Delete(characterID);
            return RedirectToAction("CharatcterList");
        }

        public ActionResult MoviesList()
        {
            List<Movies> movies = new List<Movies>();
            movies = MoviesRepository.List();
            return View(movies);
        }
        public ActionResult MovieEdit(int movieID = 0)
        {
            if (movieID > 0)
            {
                Movies movies = new Movies();
                movies = MoviesRepository.Read(movieID);
                ViewData["Image"] = "true";
                ViewData["Year"] = "true";
                return View(movies);
            }
            return View();
        }
        [HttpPost]
        public ActionResult MovieEdit(HttpPostedFileBase Image, string Year, Movies movie)
        {
            movie.Year = Year;
            if (Image != null)
            {
                movie.Image = UploadImage(Image, movie.Image);
            }
            if (movie.MoviesID > 0) MoviesRepository.Update(movie);
            else MoviesRepository.Insert(movie);
            return RedirectToAction("MoviesList");
        }
        public ActionResult MovieDelete(int movieID, string imageAddress)
        {
            string Paath = Server.MapPath("~/Images/");

            imageAddress = imageAddress.Substring(imageAddress.IndexOf("/"));
            FileInfo path = new FileInfo(Paath + imageAddress);
            path.Delete();

            MoviesRepository.Delete(movieID);
            return RedirectToAction("MoviesList");
        }
        public ActionResult MovieDetail(int MovieID)
        {
            Movies movie = new Movies();
            movie = MoviesRepository.Read(MovieID);
            return View(movie);
        }

        public string UploadImage(HttpPostedFileBase oImage, string imageAddress = "")
        {
            string Paath = Server.MapPath("~/Images/");
            string FullPath;
            if (imageAddress != null)
            {
                imageAddress = imageAddress.Substring(imageAddress.IndexOf("/"));
                FileInfo path = new FileInfo(Paath+imageAddress);
                path.Delete();
            }

            if (!Directory.Exists(Paath)) { Directory.CreateDirectory(Paath); }

            FullPath = Paath + oImage.FileName;
            oImage.SaveAs(FullPath);
            FullPath = "Images/" + oImage.FileName;
            return FullPath;
        }
    }
}