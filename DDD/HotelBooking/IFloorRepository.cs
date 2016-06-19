using System;

namespace HotelBooking
{
    public interface IFloorRepository
    {
        Room FindFloorByGuid(Guid guid);
        void SaveOrUpdate(Floor room);
    }
}