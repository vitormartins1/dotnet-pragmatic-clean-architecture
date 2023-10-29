using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings.ReservedBooking;

public record ReservedBookingCommand(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;