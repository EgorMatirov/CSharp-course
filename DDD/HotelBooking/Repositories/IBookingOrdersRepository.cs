using System;
using System.Collections.Generic;

namespace HotelBooking.Repositories
{
    public interface IBookingOrdersRepository
    {
        List<BookingOrder> GetBookingOrders();
        List<BookingOrder> GetBookingOrdersForRoom(Guid roomGuid);
        BookingOrder FindBookingOrder(Guid bookingOrederGuid);
        void SaveOrUpdate(BookingOrder bookingOrder);
    }
}