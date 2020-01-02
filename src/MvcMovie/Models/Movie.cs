using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
