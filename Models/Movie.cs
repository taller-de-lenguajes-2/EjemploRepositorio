using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2.Models
{
    public class Movie
    {
        private int id;
        private string original_title;
        private int budget;
        private int popularity;
        private string release_date;
        private int revenue;
        private string title;
        private double vote_average;
        private int vote_count;
        private string overview;
        private string tagline;
        private int uid;
        private int director_id;

        public int Id { get => id; set => id = value; }
        public string Original_title { get => original_title; set => original_title = value; }
        public int Budget { get => budget; set => budget = value; }
        public int Popularity { get => popularity; set => popularity = value; }
        public string Release_date { get => release_date; set => release_date = value; }
        public int Revenue { get => revenue; set => revenue = value; }
        public string Title { get => title; set => title = value; }
        public double Vote_average { get => vote_average; set => vote_average = value; }
        public int Vote_count { get => vote_count; set => vote_count = value; }
        public string Overview { get => overview; set => overview = value; }
        public string Tagline { get => tagline; set => tagline = value; }
        public int Uid { get => uid; set => uid = value; }
        public int Director_id { get => director_id; set => director_id = value; }
    }
}