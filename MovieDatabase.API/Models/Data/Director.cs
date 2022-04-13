using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabase.API.Models.Data;

public sealed class Director
{
    public Director()
    {
        MovieDirectors = new List<MovieDirector>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DirectorId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Birthdate { get; set; }

    [StringLength(50)] public string Country { get; set; }

    public ICollection<MovieDirector> MovieDirectors { get; }
}