namespace Domain.Entities;

public class MovieGenre : BaseEntity
{
    public Guid MovieId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string Adventure { get; set; } = string.Empty;

    public string Anime { get; set; } = string.Empty;

    public string Comedy { get; set; } = string.Empty;

    public string Drama { get; set; } = string.Empty;

    public string Documentary { get; set; } = string.Empty;

    public string Cartoon { get; set; } = string.Empty;

    public string Horror { get; set; } = string.Empty;

    public string Fantasy { get; set; } = string.Empty;

    public string Thriller { get; set; } = string.Empty;

    public ICollection<Movie> Movies { get; set; }
}