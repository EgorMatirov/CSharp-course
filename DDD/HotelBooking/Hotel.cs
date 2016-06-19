using System;
using System.Collections.Immutable;

namespace HotelBooking
{
    public class Hotel
    {
        public readonly string Name;
        public readonly Guid Guid;
        public readonly Address Address;
        public ImmutableList<Guid> Floors { get; private set; }

        public Hotel(string name, Guid guid, Address address, ImmutableList<Guid> floors)
        {
            Name = name;
            Guid = guid;
            Address = address;
            Floors = floors;
        }

        public void AddFloor(Guid floorGuid)
        {
            Floors = Floors.Add(floorGuid);
        }

        public static Hotel CreateHotel(string name, Address address, ImmutableList<Guid> roomGuids)
        {
            var guid = Guid.NewGuid();
            return new Hotel(name, guid, address, roomGuids);
        }

        protected bool Equals(Hotel other)
        {
            return Guid == other.Guid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Hotel)obj);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}
