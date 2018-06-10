using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDBnew.Model
{
    public class Person
    {
        public string Birthday { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> also_known_as { get; set; }
        public int Gender { get; set; }
        public string Biography { get; set; }
        public float Popularity { get; set; }
        public string place_of_birth { get; set; }
        public string profile_path { get; set; }
        public bool Adult { get; set; }
        public string imdb_id { get; set; }
        public string Homepage { get; set; }
    }

}
