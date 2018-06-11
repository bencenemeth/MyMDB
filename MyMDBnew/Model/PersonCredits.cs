using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDBnew.Model
{
    public class PersonCredits
    {
        public List<Movie> Cast { get; set; }
        public List<Movie> Crew { get; set; }
    }
}
