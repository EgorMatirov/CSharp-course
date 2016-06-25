using System;
using System.Linq;
using HotelBooking.Repositories;

namespace HotelBooking
{
    public class RoomAvailabilityService
    {
        public readonly IBookingOrdersRepository BookingOrdersRepository;

        public RoomAvailabilityService(IBookingOrdersRepository bookingOrdersRepository)
        {
            BookingOrdersRepository = bookingOrdersRepository;
        }

        public bool IsAvailable(Guid roomGuid, DateTime checkInDateTime, DateTime checkOutDateTime)
        {
            return !BookingOrdersRepository
                .GetBookingOrdersForRoom(roomGuid)
                .Any(x => checkInDateTime <= x.CheckInDateTime && x.CheckOutDateTime <= checkOutDateTime);
        }
    }
}