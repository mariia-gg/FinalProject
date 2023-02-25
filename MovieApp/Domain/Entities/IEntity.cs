using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public interface IEntity
{
    [Key]
    public Guid Id { get; set; }
}