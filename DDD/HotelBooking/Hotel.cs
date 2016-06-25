using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace HotelBooking
{
    public class Hotel
    {
        public readonly Address Address;
        public readonly Guid Guid;
        public readonly string Name;

        public Hotel(string name, Guid guid, Address address, ImmutableList<Floor> floors)
        {
            Name = name;
            Guid = guid;
            Address = address;
            Floors = floors;
        }

        public ImmutableList<Floor> Floors { get; private set; }
        public IEnumerable<Room> Rooms => Floors.SelectMany(floor => floor.Rooms);

        public void AddFloor(Floor floor)
        {
            Floors = Floors.Add(floor);
        }

        public static Hotel CreateHotel(string name, Address address, ImmutableList<Floor> floors)
        {
            var guid = Guid.NewGuid();
            return new Hotel(name, guid, address, floors);
        }

        #region Equals and hash code

        protected bool Equals(Hotel other)
        {
            return Guid == other.Guid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Hotel) obj);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        #endregion
    }
}