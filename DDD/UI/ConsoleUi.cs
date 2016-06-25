using System;
using System.Collections.Generic;
using Application;
using HotelBooking;

namespace UI
{
    internal class ConsoleUi : IUi
    {
        public void DisplayHotels(IEnumerable<Hotel> hotels)
        {
            throw new NotImplementedException();
        }

        public void DisplayRooms(IEnumerable<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public void DisplayFilters(IEnumerable<IFilter> filters)
        {
            throw new NotImplementedException();
        }

        public List<IFilter> GetSelectedFilters()
        {
            throw new NotImplementedException();
        }
    }
}