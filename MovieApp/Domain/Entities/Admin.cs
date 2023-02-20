namespace Domain.Entities;

public class Admin : BaseEntity, IEntity
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public ICollection<Actor>? Actors { get; set; }

    public ICollection<Movie> Movies { get; set; }

    public ICollection<Login> Logins { get; set; }

    public ICollection<MovieGenre> MovieGenres { get; set; }
}