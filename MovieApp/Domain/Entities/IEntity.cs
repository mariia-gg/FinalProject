using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public interface IEntity
{
    [Key]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}