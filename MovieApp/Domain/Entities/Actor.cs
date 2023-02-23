using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Actor : BaseEntity, IEntity
{
    public Guid FilmId { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile Picture is required")]
    public string ProfilePictureUrl { get; set; } = string.Empty;

    [Display(Name = "Biography")]
    [Required(ErrorMessage = "Biography is required")]
    public string Bio { get; set; } = string.Empty;

    //public Movie Movies { get; set; }

    //public ICollection<MovieGenre> MovieGenres { get; set; }
}