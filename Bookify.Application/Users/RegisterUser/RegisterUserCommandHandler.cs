﻿using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository, 
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _authenticationService = authenticationService;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request, 
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email));

        var identityId = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);

        user.SetIdentityId(identityId);

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }
}
