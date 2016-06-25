using System;
using HotelBooking;

namespace Application
{
    class HotelFilter : IFilter
    {
        public readonly Guid HotelGuid;

        public HotelFilter(Guid hotelGuid)
        {
            HotelGuid = hotelGuid;
        }

        public bool RoomMatches(Room room)
        {
            return HotelGuid == room.HotelGuid;
        }
    }
}