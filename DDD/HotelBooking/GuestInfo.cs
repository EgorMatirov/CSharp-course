namespace HotelBooking
{
    public class GuestInfo
    {
        public readonly string FirstName;
        public readonly string LastName;

        public GuestInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        #region Equals and hash code

        protected bool Equals(GuestInfo other)
        {
            return FirstName == other.FirstName
                   && LastName == other.LastName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GuestInfo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = (int) 2166136261;
                hash = (hash*16777619) ^ FirstName.GetHashCode();
                hash = (hash*16777619) ^ LastName.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}