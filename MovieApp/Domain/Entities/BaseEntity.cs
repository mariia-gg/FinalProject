namespace Domain.Entities;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }
}