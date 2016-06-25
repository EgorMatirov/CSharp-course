using HotelBooking;

namespace Application
{
    public interface IFilter
    {
        bool RoomMatches(Room room);
    }
}