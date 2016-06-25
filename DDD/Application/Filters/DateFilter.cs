using System;
using HotelBooking;

namespace Application
{
    public class DateFilter : IFilter
    {
        public readonly DateTime CheckInDateTime;
        public readonly DateTime CheckOutDateTime;
        private readonly RoomAvailabilityService _roomAvailabilityService;

        public DateFilter(DateTime checkInDateTime, DateTime checkOutDateTime, RoomAvailabilityService roomAvailabilityService)
        {
            CheckInDateTime = checkInDateTime;
            CheckOutDateTime = checkOutDateTime;
            _roomAvailabilityService = roomAvailabilityService;
        }

        public bool RoomMatches(Room room)
        {
            return _roomAvailabilityService.IsAvailable(room.Guid, CheckInDateTime, CheckOutDateTime);
        }
    }
}