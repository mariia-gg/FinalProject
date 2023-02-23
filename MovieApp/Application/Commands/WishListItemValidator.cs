using Domain.Entities;
using FluentValidation;

namespace Application.Commands;

public class WishListItemValidator : AbstractValidator<WishListItem>
{
    public WishListItemValidator()
    {
        RuleFor(createWishListItem => createWishListItem.MovieTitle).NotEmpty().MaximumLength(250);
        RuleFor(createWishListItem => createWishListItem.MovieId).NotEqual(Guid.Empty);
        RuleFor(createWishListItem => createWishListItem.MovieId).NotEqual(Guid.Empty);
    }
}