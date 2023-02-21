using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.Common.Entities;

public class Login : BaseEntity, IEntity
{
    [Display(Name = "User  ")]
    [Required(ErrorMessage = "UserName address is required")]
    public string UserName { get; set; } = string.Empty;


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}