using System;

namespace HotelBooking
{
    public interface IRoomRepository
    {
        Room FindRoomByGuid(Guid guid);
        void SaveOrUpdate(Room room);
    }
}