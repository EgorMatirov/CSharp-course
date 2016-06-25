using System.Collections.Generic;
using Application;
using HotelBooking.Repositories;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUi();
            var searchService = new SearchService(GetHotelRepository(), GetBookingOrderRepository(), GetRoomRepository());
            ui.DisplayFilters(GetAvailableFilters());
            var selectedFilters = ui.GetSelectedFilters();
            
            ui.DisplayHotels(searchService.FindHotels(selectedFilters));
        }

        private static IHotelRepository GetHotelRepository()
        {
            throw new System.NotImplementedException();
        }

        private static IBookingOrdersRepository GetBookingOrderRepository()
        {
            throw new System.NotImplementedException();
        }

        private static IRoomRepository GetRoomRepository()
        {
            throw new System.NotImplementedException();
        }

        private static List<IFilter> GetAvailableFilters()
        {
            throw new System.NotImplementedException();
        }
    }
}
