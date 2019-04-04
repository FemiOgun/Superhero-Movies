using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.SHC.Models;

namespace Web.SHC.Repository
{
    public class MoviesRepository
    {
        static SHCContext context = new SHCContext();
        public static Movies Insert(Movies movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return movie;
        }
        public static Movies Read(int movieID)
        {
            Movies movie = null;
            movie = context.Movies
                        .Where(a => a.MoviesID == movieID)
                        .FirstOrDefault();
            return movie;
        }
        public static void Update(Movies movie)
        {
            Movies mov = new Movies();
            mov = context.Movies.Find(movie.MoviesID);
            mov.Title = movie.Title;
            mov.PlotSummary = movie.PlotSummary;
            mov.Year = movie.Year;
            mov.Image = movie.Image;
            mov.Rating = movie.Rating;
            context.SaveChanges();
        }
        public static void Delete(int movieID)
        {
            Movies movie = context.Movies.Where(a => a.MoviesID == movieID).FirstOrDefault();
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
        public static List<Movies> List()
        {
            List<Movies> movies = context.Movies.Include(a => a.Characters).ToList();
            return movies;
        }
    }
}