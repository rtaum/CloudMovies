using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudMovies.Database.Models
{
    public class Actor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public IEnumerable<MovieActor> ActorMovies { get; set; }
    }
}
