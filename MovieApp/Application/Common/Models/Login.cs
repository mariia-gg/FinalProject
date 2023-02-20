using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Common.Entities;

public class Login : BaseEntity, IEntity
{
    [Display(Name = "Email address")]
    [Required(ErrorMessage = "Email address is required")]
    public string Email { get; set; } = string.Empty;


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}