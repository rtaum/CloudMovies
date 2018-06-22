using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudMovies.Database.Models
{
    public class MovieActor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("MovieForeignKey")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("ActorForeignKey")]
        public int ActorId { get; set; }

        public Actor Actor{ get; set; }
    }
}
