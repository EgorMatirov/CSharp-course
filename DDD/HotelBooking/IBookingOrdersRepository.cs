using System;
using System.Collections.Generic;

namespace HotelBooking
{
    public interface IBookingOrdersRepository
    {
        List<BookingOrder> GetBookingOrdersls();
        BookingOrder FindBookingOrder(Guid guid);
        void SaveOrUpdate(BookingOrder bookingOrder);
    }
}