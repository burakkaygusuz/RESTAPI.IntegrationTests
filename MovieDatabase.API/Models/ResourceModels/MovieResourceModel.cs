namespace MovieDatabase.API.Models.ResourceModels;

public class MovieResourceModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ReleaseYear { get; set; }
    public double IMDBRating { get; set; }
    public IEnumerable<string> Directors { get; set; }
}