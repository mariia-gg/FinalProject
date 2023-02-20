using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Movie : BaseEntity, IEntity
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string ImageURL { get; set; } = string.Empty;


    public ICollection<MovieGenre> Genres { get; set; }

    public ICollection<WishListItem> WishListItems { get; set; }

    public ICollection<Actor> Actors { get; set; }

    public DateTime CreatedAt { get; set; }
}