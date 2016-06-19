using System;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;

namespace HotelBooking
{
    public class Floor
    {
        public readonly Guid Guid;
        public Image Plan { get; set; }
        public ImmutableList<RoomPositionInfo> RoomPositions { get; private set; }

        private Floor(Guid guid, Image plan, ImmutableList<RoomPositionInfo> roomPositions)
        {
            Plan = plan;
            RoomPositions = roomPositions;
            Guid = guid;
        }

        public static Floor CreateFloor(Image plan, ImmutableList<RoomPositionInfo> roomPositions, Guid? guid = null)
        {
            if (roomPositions.Any(x => x.Position.Bottom > plan.Height || x.Position.Right > plan.Width))
                throw new ArgumentException("Invalid room positions");
            if( guid == null)
                guid = Guid.NewGuid();
            return new Floor(guid.Value, plan, roomPositions);
        }

        public void AddRoomPosition(RoomPositionInfo roomPosition)
        {
            if (roomPosition.Position.Bottom > Plan.Height || roomPosition.Position.Right > Plan.Width)
                throw new ArgumentException("Invalid room position");
            RoomPositions = RoomPositions.Add(roomPosition);
        }
    }
}