using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDBnew.Model
{

    public class Show
    {
        public string BackdropPath { get; set; }
        public List<CreatedBy> created_by { get; set; }
        public List<int> episode_run_time { get; set; }
        public string first_air_date { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public bool in_production { get; set; }
        public List<string> languages { get; set; }
        public string last_air_date { get; set; }
        public string Name { get; set; }
        public Network[] Networks { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public string[] origin_country { get; set; }
        public string original_language { get; set; }
        public string original_name { get; set; }
        public string Overview { get; set; }
        public float Popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompanies> production_companies { get; set; }
        public List<ShowSeason> seasons { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        
        public string MediaType { get; set; }
    }
    /*
    public class Created_By
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Network
    {
        public string name { get; set; }
        public int id { get; set; }
        public string logo_path { get; set; }
        public string origin_country { get; set; }
    }

    public class Production_Companies
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class Season
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }
    */
}
