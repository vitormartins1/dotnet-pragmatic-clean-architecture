namespace Bookify.Api.Controllers.Users;

public sealed record LogInUserRequest(
    string Password,
    string Email);