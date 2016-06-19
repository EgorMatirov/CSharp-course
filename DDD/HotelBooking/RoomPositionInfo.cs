using System;
using System.Drawing;

namespace HotelBooking
{
    public class RoomPositionInfo
    {
        public readonly Rectangle Position;
        public readonly Guid RoomGuid;

        private RoomPositionInfo(Rectangle position, Guid roomGuid)
        {
            Position = position;
            RoomGuid = roomGuid;
        }

        public static RoomPositionInfo CreatePositionInfo(Rectangle position, Guid roomGuid)
        {
            if(position.Left < 0 || position.Top <0)
                throw new ArgumentException("Wrong position: left and top should be greater than 0");
            return new RoomPositionInfo(position, roomGuid);
        }
    }
}