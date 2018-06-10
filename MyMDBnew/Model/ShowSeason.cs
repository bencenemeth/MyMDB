using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDBnew.Model
{
    public class ShowSeason
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }
}
