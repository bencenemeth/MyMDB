﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDBnew.Model
{
    public class ListResult<T>
    {
        public int Page { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public List<T> Results { get; set; }
    }
}
