using System;
using System.Collections.Generic;

namespace HotelBooking.Repositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetHotels();
        Hotel FindHotelByGuid(Guid guid);
        void SaveOrUpdate(Hotel hotel);
    }
}