using System;
using System.Drawing;

namespace HotelBooking
{
    public class Room
    {
        public enum BedType
        {
            Single,
            Double,
            King
        }
        
        public readonly Guid Guid;
        public readonly Rectangle Position;

        public Room(Guid guid, Guid hotelGuid, BedType bedsType, uint bedsCount, bool hasTv, bool hasBalcony, Cost cost, Rectangle position)
        {
            Guid = guid;
            HotelGuid = hotelGuid;
            BedsType = bedsType;
            BedsCount = bedsCount;
            HasTv = hasTv;
            HasBalcony = hasBalcony;
            Cost = cost;
            Position = position;
        }

        public BedType BedsType { get; set; }
        public uint BedsCount { get; set; }
        public bool HasTv { get; set; }
        public bool HasBalcony { get; set; }
        public Cost Cost { get; set; }
        public Guid HotelGuid { get; set; }

        public static Room CreateRoom(Guid hotelGuid, BedType bedsType, uint bedsCount, bool hasTv, bool hasBalcony, Cost cost,
            Rectangle position)
        {
            if (position.Left < 0 || position.Top < 0)
                throw new ArgumentException("Wrong position: left and top should be greater than 0");
            var guid = Guid.NewGuid();

            return new Room(guid, hotelGuid, bedsType, bedsCount, hasTv, hasBalcony, cost, position);
        }

        #region Equals and hash code

        protected bool Equals(Room other)
        {
            return Guid == other.Guid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Room)obj);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        #endregion
    }
}