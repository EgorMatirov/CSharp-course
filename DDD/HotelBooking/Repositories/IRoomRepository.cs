using System;
using System.Collections.Generic;

namespace HotelBooking.Repositories
{
    public interface IRoomRepository
    {
        List<Room> GetRooms();
        Room FindRoomByGuid(Guid guid);
        void SaveOrUpdate(Room room);
    }
}