using System;

namespace HotelBooking
{
    public class BookedDates
    {
        public readonly DateTime CheckInDateTime;
        public readonly DateTime CheckOutDateTime;

        public BookedDates(DateTime checkInDateTime, DateTime checkOutDateTime)
        {
            if( CheckOutDateTime <= CheckInDateTime )
                throw new ArgumentException("Checkout date should be greater than checkin date.");
            CheckInDateTime = checkInDateTime;
            CheckOutDateTime = checkOutDateTime;
        }

        public bool Contains(DateTime dateTime)
        {
            return CheckInDateTime <= dateTime && dateTime <= CheckOutDateTime;
        }

        protected bool Equals(BookedDates other)
        {
            return CheckInDateTime == other.CheckInDateTime
                && CheckOutDateTime == other.CheckOutDateTime;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((BookedDates)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = (int)2166136261;
                hash = (hash * 16777619) ^ CheckInDateTime.GetHashCode();
                hash = (hash * 16777619) ^ CheckOutDateTime.GetHashCode();
                return hash;
            }
        }
    }
}