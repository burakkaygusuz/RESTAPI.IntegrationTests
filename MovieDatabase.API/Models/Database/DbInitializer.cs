using MovieDatabase.API.Models.Data;

namespace MovieDatabase.API.Models.Database;

public static class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<MovieDatabaseContext>();

        if (dbContext != null && await dbContext.Database.EnsureCreatedAsync())
            await InsertSampleData(serviceProvider);
    }

    private static async Task InsertSampleData(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetService<MovieDatabaseContext>();

        if (dbContext != null)
        {
            await dbContext.Movies.AddRangeAsync(
                new Movie
                {
                    MovieId = 1,
                    Title = "Hangover",
                    ReleaseYear = new DateTime(2009, 06, 05),
                    Rating = 7.7
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "Interstellar",
                    ReleaseYear = new DateTime(2014, 11, 07),
                    Rating = 8.6
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "Django Unchained",
                    ReleaseYear = new DateTime(2012, 12, 25),
                    Rating = 8.4
                },
                new Movie
                {
                    MovieId = 4,
                    Title = "Schindler's List",
                    ReleaseYear = new DateTime(1994, 02, 04),
                    Rating = 8.9
                },
                new Movie
                {
                    MovieId = 5,
                    Title = "City of God",
                    ReleaseYear = new DateTime(2004, 02, 13),
                    Rating = 8.6
                });

            await dbContext.SaveChangesAsync();

            await dbContext.Directors.AddRangeAsync(
                new Director
                {
                    DirectorId = 1,
                    FirstName = "Todd",
                    LastName = "Philips",
                    Birthdate = new DateTime(1970, 12, 20),
                    Country = "United States"
                },
                new Director
                {
                    DirectorId = 2,
                    FirstName = "Christopher",
                    LastName = "Nolan",
                    Birthdate = new DateTime(1970, 07, 30),
                    Country = "United Kingdom"
                },
                new Director
                {
                    DirectorId = 3,
                    FirstName = "Quentin",
                    LastName = "Tarantino",
                    Birthdate = new DateTime(1963, 03, 27),
                    Country = "United States"
                },
                new Director
                {
                    DirectorId = 4,
                    FirstName = "Steven",
                    LastName = "Spielberg",
                    Birthdate = new DateTime(1946, 12, 18),
                    Country = "United States"
                },
                new Director
                {
                    DirectorId = 5,
                    FirstName = "Fernando",
                    LastName = "Meirelles",
                    Birthdate = new DateTime(1955, 11, 09),
                    Country = "Brazil"
                },
                new Director
                {
                    DirectorId = 6,
                    FirstName = "Kátia",
                    LastName = "Lund",
                    Birthdate = new DateTime(1966, 01, 01),
                    Country = "Brazil"
                });

            await dbContext.SaveChangesAsync();

            await dbContext.Genres.AddRangeAsync(
                new Genre
                {
                    GenreId = 1,
                    Name = "Comedy",
                    Description = "A comedy film is a genre of film in which the main emphasis is on humor. " +
                                  "These films are designed to make the audience laugh through amusement and most often work by exaggerating characteristics for humorous effect."
                },
                new Genre
                {
                    GenreId = 2,
                    Name = "Adventure",
                    Description =
                        "Adventure films are a genre of film that typically use their action scenes to display and explore exotic locations in an energetic way."
                },
                new Genre
                {
                    GenreId = 3,
                    Name = "Drama",
                    Description =
                        "Drama is a genre of narrative fiction (or semi-fiction) intended to be more serious than humorous in tone."
                },
                new Genre
                {
                    GenreId = 4,
                    Name = "Sci-Fi",
                    Description =
                        "Science fiction film is a genre that uses speculative, fictional science-based depictions of phenomena that are not fully accepted by mainstream science," +
                        " such as extraterrestrial lifeforms, alien worlds, extrasensory perception and time travel, along with futuristic elements such as spacecraft, robots, cyborgs, interstellar travel or other technologies."
                },
                new Genre
                {
                    GenreId = 5,
                    Name = "Western",
                    Description =
                        "Western is a genre of fiction incorporating Western lifestyle which tell stories set primarily in the latter half of the 19th century in the American Old West, " +
                        "often centering on the life of a nomadic cowboy or gunfighter armed with a revolver and a rifle who rides a horse."
                },
                new Genre
                {
                    GenreId = 6,
                    Name = "Historical",
                    Description =
                        "A historical film is a fiction film showing past events or set within a historical period."
                },
                new Genre
                {
                    GenreId = 7,
                    Name = "Biographical",
                    Description =
                        "A film that tells the story of the life of a real person, often a monarch, political leader, or artist."
                },
                new Genre
                {
                    GenreId = 8,
                    Name = "Crime",
                    Description =
                        "An extremely wide-ranging group of fiction films that have crime as a central element of their plots."
                });

            await dbContext.SaveChangesAsync();

            await dbContext.MovieDirectors.AddRangeAsync(
                new MovieDirector
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Hangover")!.MovieId,
                    DirectorId =
                        dbContext.Directors.SingleOrDefault(d => d.FirstName == "Todd" && d.LastName == "Philips")!
                            .DirectorId
                },
                new MovieDirector
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Interstellar")!.MovieId,
                    DirectorId =
                        dbContext.Directors.SingleOrDefault(d => d.FirstName == "Christopher" && d.LastName == "Nolan")!
                            .DirectorId
                },
                new MovieDirector
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Django Unchained")!.MovieId,
                    DirectorId =
                        dbContext.Directors.SingleOrDefault(d => d.FirstName == "Quentin" && d.LastName == "Tarantino")!
                            .DirectorId
                },
                new MovieDirector
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Schindler's List")!.MovieId,
                    DirectorId =
                        dbContext.Directors.SingleOrDefault(d => d.FirstName == "Steven" && d.LastName == "Spielberg")!
                            .DirectorId
                },
                new MovieDirector
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "City of God")!.MovieId,
                    DirectorId =
                        dbContext.Directors.SingleOrDefault(d =>
                            d.FirstName == "Fernando" && d.LastName == "Meirelles")!.DirectorId
                },
                new MovieDirector
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "City of God")!.MovieId,
                    DirectorId =
                        dbContext.Directors.SingleOrDefault(d => d.FirstName == "Kátia" && d.LastName == "Lund")!
                            .DirectorId
                });

            await dbContext.SaveChangesAsync();

            await dbContext.MovieGenres.AddRangeAsync(
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Hangover")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Comedy")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Interstellar")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Adventure")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Interstellar")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Sci-Fi")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Interstellar")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Drama")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Django Unchained")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Western")!.GenreId
                }, new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Django Unchained")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Drama")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Schindler's List")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Historical")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "Schindler's List")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Biographical")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "City of God")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Crime")!.GenreId
                },
                new MovieGenre
                {
                    MovieId = dbContext.Movies.SingleOrDefault(m => m.Title == "City of God")!.MovieId,
                    GenreId = dbContext.Genres.SingleOrDefault(g => g.Name == "Drama")!.GenreId
                });

            await dbContext.SaveChangesAsync();
        }
    }
}