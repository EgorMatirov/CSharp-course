using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;

namespace HotelBooking
{
    public class Floor
    {
        public readonly Guid Guid;

        private Floor(Guid guid, Image plan, ImmutableList<Room> rooms)
        {
            Plan = plan;
            Rooms = rooms;
            Guid = guid;
        }

        public Image Plan { get; set; }
        public ImmutableList<Room> Rooms { get; private set; }

        public static Floor CreateFloor(Image plan, ImmutableList<Room> rooms, Guid? guid = null)
        {
            if (rooms.Any(x => !IsValidPosition(x.Position, plan)))
                throw new ArgumentException("Invalid room positions");
            if (guid == null)
                guid = Guid.NewGuid();
            return new Floor(guid.Value, plan, rooms);
        }

        public void AddRoom(Room room)
        {
            if (!IsValidPosition(room.Position, Plan))
                throw new ArgumentException("Invalid room position");
            Rooms = Rooms.Add(room);
        }

        private static bool IsValidPosition(Rectangle roomPosition, Image plan)
        {
            return roomPosition.Bottom <= plan.Height && roomPosition.Right <= plan.Width;
        }

        #region Equals and hash code

        protected bool Equals(Floor other)
        {
            return Guid == other.Guid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Floor) obj);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        #endregion
    }
}