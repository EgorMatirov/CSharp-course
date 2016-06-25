using System.Collections.Generic;
using Application;
using HotelBooking;

namespace UI
{
    internal interface IUi
    {
        void DisplayHotels(IEnumerable<Hotel> hotels);
        void DisplayRooms(IEnumerable<Room> rooms);
        void DisplayFilters(IEnumerable<IFilter> filters);
        List<IFilter> GetSelectedFilters();
    }
}