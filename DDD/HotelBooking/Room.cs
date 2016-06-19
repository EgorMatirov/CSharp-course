using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking
{
    public class Room
    {
        public readonly Guid Guid;
        public BedType BedsType { get; set; }
        public uint BedsCount { get; set; }
        public bool HasTv { get; set; }
        public bool HasBalcony { get; set; }
        public Cost Cost { get; set; }
        private readonly List<BookedDates> _bookedDates;

        public Room(Guid guid, BedType bedsType, uint bedsCount, bool hasTv, bool hasBalcony, Cost cost, List<BookedDates> bookedDates)
        {
            Guid = guid;
            BedsType = bedsType;
            BedsCount = bedsCount;
            HasTv = hasTv;
            HasBalcony = hasBalcony;
            Cost = cost;
            _bookedDates = bookedDates;
        }

        public static Room CreateRoom(BedType bedsType, uint bedsCount, bool hasTv, bool hasBalcony, Cost cost)
        {
            var guid = Guid.NewGuid();
            var bookedDates = new List<BookedDates>();

            return new Room(guid, bedsType, bedsCount, hasTv, hasBalcony, cost, bookedDates);
        }

        public bool IsAvailableAt(DateTime dateTime)
        {
            return _bookedDates.Any(x => x.Contains(dateTime));
        }

        public bool IsAvailableAt(BookedDates dates)
        {
            return !_bookedDates.Any(x => x.CheckInDateTime > dates.CheckInDateTime && x.CheckOutDateTime < dates.CheckOutDateTime);
        }
        
        public enum BedType
        {
            Single,
            Double,
            King
        }
    }
}