using System;

namespace HotelBooking.Repositories
{
    public interface IFloorRepository
    {
        Floor FindFloorByGuid(Guid guid);
        void SaveOrUpdate(Floor room);
    }
}