namespace HotelBooking
{
    public class Address
    {
        public readonly string City;
        public readonly string Country;
        public readonly string PostalCode;
        public readonly string Region;
        public readonly string Street;

        public Address(string street, string city, string region, string country, string postalCode)
        {
            Street = street;
            City = city;
            Region = region;
            Country = country;
            PostalCode = postalCode;
        }

        #region Equals and hash code

        protected bool Equals(Address other)
        {
            return Street == other.Street
                   && City == other.City
                   && Region == other.Region
                   && Country == other.Country
                   && PostalCode == other.PostalCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = (int) 2166136261;
                hash = (hash*16777619) ^ Street.GetHashCode();
                hash = (hash*16777619) ^ City.GetHashCode();
                hash = (hash*16777619) ^ Region.GetHashCode();
                hash = (hash*16777619) ^ Country.GetHashCode();
                hash = (hash*16777619) ^ PostalCode.GetHashCode();
                return hash;
            }
        }

        #endregion
    }
}