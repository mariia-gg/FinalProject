using Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.IdentityService;

public class IdentityResultExtensions
{
    public static Result ToApplicationResult(IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}