﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudMovies.Database.Models
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        
        public int Year { get; set; }
        
        public string Genre { get; set; }

        public IEnumerable<MovieActor> MovieActors { get; set; }
    }
}
