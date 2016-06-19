using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HotelBooking
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotels();
        Match FindHotelByGuid(Guid guid);
        void SaveOrUpdate(Hotel hotel);
    }
}