using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MyMDBnew.Model
{
    public class Movie
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public BelongsToCollection belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompanies> production_companies { get; set; }
        public List<ProductionCountries> production_countries { get; set; }
        public string release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguages> spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }

        public List<int> genre_ids { get; set; }

        public string MediaType { get; set; }
    }
}
