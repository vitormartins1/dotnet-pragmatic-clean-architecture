﻿using FluentValidation;

namespace Bookify.Application.Bookings.ReservedBooking;

public class ReserveBookingCommandValidator : AbstractValidator<ReservedBookingCommand>
{
    public ReserveBookingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ApartmentId).NotEmpty();
        RuleFor(c => c.StartDate).LessThan(c => c.EndDate);
    }
}