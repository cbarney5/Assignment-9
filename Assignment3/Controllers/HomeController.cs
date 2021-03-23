using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment3.Models;
using Assignment3.Models.ViewModels;
using System.Net;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private MovieDbContext context { get; set; }

        public HomeController(MovieDbContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Movie()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Movie(ApplicationResponse appResponse)
        {
            if (ModelState.IsValid)
            { 
                context.Movies.Add(appResponse);
                context.SaveChanges();
                
                
            }
            return View("MovieCollection", new MovieCollectionViewModel()
            {
                ApplicationResponses = context.Movies
              .Select(s => s)
            });
        }
        [HttpGet]
        public IActionResult MovieCollection()
        {
            return View(new MovieCollectionViewModel
            {
                ApplicationResponses = context.Movies.Select(s => s)
            });
        }

        [HttpPost]
        public IActionResult MovieCollection(int id)
        {

            ApplicationResponse Movie = context.Movies.Where(x => x.MovieId == id).FirstOrDefault();

            ViewData["id"] = id;

            return View("EditMovie", Movie);
            
           
        }
        [HttpPost]
        public IActionResult EditMovie(ApplicationResponse mov, int id)
        {
            ApplicationResponse originalMovie = context.Movies.Where(s => s.MovieId == id).FirstOrDefault();
            int ID = id;
            originalMovie.category = mov.category;
            originalMovie.title = mov.title;
            originalMovie.year = mov.year;
            originalMovie.director = mov.director;
            originalMovie.rating = mov.rating;
            originalMovie.edited = mov.edited;
            originalMovie.lentTo = mov.lentTo;
            originalMovie.category = mov.category;
            originalMovie.notes = mov.notes;

            context.Update(originalMovie);
            context.SaveChanges();

            return View("MovieCollection", new MovieCollectionViewModel
            {
                ApplicationResponses = context.Movies.Select(s => s)
            });
        }

        public IActionResult DeleteMovie(int id)
        {
            ApplicationResponse Movie = context.Movies.Where(x => x.MovieId == id).FirstOrDefault();

            context.Movies.Remove(Movie);
            context.SaveChanges();

            return View("MovieCollection", new MovieCollectionViewModel
            {
                ApplicationResponses = context.Movies.Select(s => s)
            });
        }

        public IActionResult Privacy()
        {
            return View("MovieList", new MovieCollectionViewModel()
            {
                ApplicationResponses = context.Movies
                .Select(s => s)
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult myPodcasts()
        {
            return View();
        }

    }
}
