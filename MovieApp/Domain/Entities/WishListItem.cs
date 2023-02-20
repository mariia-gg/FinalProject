using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class WishListItem : BaseEntity, IEntity
{
    [ForeignKey("MovieId")]
    public Guid MovieId { get; set; }

    [ForeignKey("UserId")]
    public Guid UserId { get; set; }

    // TODO: create user property when library will be added 

    public Movie? Movie { get; set; }

    //public ICollection<MovieGenre> MovieGenres { get; set; }

    //  public ICollection<User> Users { get; set; }
}