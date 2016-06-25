using System;
using HotelBooking.Repositories;

namespace HotelBooking
{
    public class BookingOrder
    {
        private readonly IRoomRepository _roomRepository;
        public readonly uint AdultsCount;
        public readonly DateTime CheckInDateTime;
        public readonly DateTime CheckOutDateTime;
        public readonly uint ChildrenCount;
        public readonly Cost Cost;
        public readonly Guid FloorGuid;
        public readonly GuestInfo GuestInfo;
        public readonly Guid Guid;
        public readonly Guid HotelGuid;
        public readonly Guid RoomGuid;

        public BookingOrder(Guid guid, Guid hotelGuid, Guid floorGuid, Guid roomGuid,
            uint adultsCount, uint childrenCount, GuestInfo guestInfo, DateTime checkInDateTime,
            DateTime checkOutDateTime, IRoomRepository roomRepository)
        {
            Guid = guid;
            HotelGuid = hotelGuid;
            FloorGuid = floorGuid;
            RoomGuid = roomGuid;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            GuestInfo = guestInfo;
            CheckInDateTime = checkInDateTime;
            CheckOutDateTime = checkOutDateTime;
            _roomRepository = roomRepository;
            Cost = CalculateCost();
        }

        public static BookingOrder NewOrder(Guid hotelGuid, Guid floorGuid, Guid roomGuid, uint adultsCount,
            uint childrenCount, GuestInfo guestInfo,
            DateTime checkInDateTime, DateTime checkOutDateTime, IRoomRepository roomRepository)
        {
            var guid = Guid.NewGuid();
            return new BookingOrder(guid, hotelGuid, floorGuid, roomGuid, adultsCount, childrenCount, guestInfo,
                checkInDateTime, checkOutDateTime, roomRepository);
        }

        private Cost CalculateCost()
        {
            var roomCost = _roomRepository.FindRoomByGuid(RoomGuid).Cost;
            throw new NotImplementedException();
        }

        #region Equals and hash code

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

        #endregion
    }
}