using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabase.API.Models.Data;

public sealed class Genre
{
    public Genre()
    {
        MovieGenres = new List<MovieGenre>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int GenreId { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    public string Name { get; set; }

    [StringLength(1000)] public string Description { get; set; }

    public IList<MovieGenre> MovieGenres { get; }
}