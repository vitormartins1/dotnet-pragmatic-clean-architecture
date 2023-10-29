using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext) 
        : base(dbContext)
    {
    }
}