using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabase.API.Models.Data;

public sealed class Movie
{
    public Movie()
    {
        MovieDirectors = new List<MovieDirector>();
        MovieGenres = new List<MovieGenre>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int MovieId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    public string Title { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ReleaseYear { get; set; }

    [Required] [Range(1, 10)] public double Rating { get; set; }

    public IList<MovieDirector> MovieDirectors { get; }
    public IList<MovieGenre> MovieGenres { get; }
}