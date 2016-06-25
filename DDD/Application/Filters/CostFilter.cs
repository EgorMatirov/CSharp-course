using HotelBooking;

namespace Application
{
    class CostFilter : IFilter
    {
        public readonly Cost MinCost;
        public readonly Cost MaxCost;

        public CostFilter(Cost minCost, Cost maxCost)
        {
            MinCost = minCost;
            MaxCost = maxCost;
        }

        public bool RoomMatches(Room room)
        {
            return MinCost <= room.Cost && room.Cost <= MaxCost;
        }
    }
}