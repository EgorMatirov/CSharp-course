using System;

namespace HotelBooking
{
    public class BookingOrder
    {
        public readonly uint AdultsCount;
        public readonly BookedDates BookedDates;
        public readonly uint ChildrenCount;
        public readonly Cost Cost;
        public readonly GuestInfo GuestInfo;
        public readonly Guid Guid;
        public readonly Hotel Hotel;
        public readonly Room Room;

        public BookingOrder(Guid guid, Hotel hotel, Room room, BookedDates bookedDates,
            uint adultsCount, uint childrenCount, GuestInfo guestInfo)
        {
            Guid = guid;
            Hotel = hotel;
            Room = room;
            BookedDates = bookedDates;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            GuestInfo = guestInfo;
            Cost = CalculateCost();
        }

        public static BookingOrder NewOrder(Hotel hotel, Room room, BookedDates bookedDates,
            uint adultsCount, uint childrenCount, GuestInfo guestInfo)
        {
            var guid = Guid.NewGuid();
            return new BookingOrder(guid, hotel, room, bookedDates, adultsCount, childrenCount, guestInfo);
        }

        private Cost CalculateCost()
        {
            return Cost.FromUsd(Room.Cost.UsdCost*(AdultsCount + 0.5*ChildrenCount));
        }

        protected bool Equals(BookingOrder otherOrder)
        {
            return Guid.Equals(otherOrder.Guid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BookingOrder) obj);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}