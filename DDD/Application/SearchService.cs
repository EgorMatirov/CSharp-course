using System.Collections.Generic;
using System.Linq;
using HotelBooking;
using HotelBooking.Repositories;

namespace Application
{
    public class SearchService
    {
        public readonly IHotelRepository HotelRepository;
        public readonly IRoomRepository RoomRepository;
        public readonly IBookingOrdersRepository BookingOrdersRepository;

        public SearchService(IHotelRepository hotelRepository, IBookingOrdersRepository bookingOrdersRepository, IRoomRepository roomRepository)
        {
            HotelRepository = hotelRepository;
            BookingOrdersRepository = bookingOrdersRepository;
            RoomRepository = roomRepository;
        }

        public IEnumerable<Hotel> FindHotels(List<IFilter> filters)
        {
            return HotelRepository
                .GetHotels()
                .Where(hotel => hotel.Rooms.Any(room => filters.All(filter => filter.RoomMatches(room))));
        }

        public IEnumerable<Room> FindRooms(List<IFilter> filters)
        {
            return RoomRepository.GetRooms().Where(room => filters.All(filter => filter.RoomMatches(room)));
        } 
    }
}
