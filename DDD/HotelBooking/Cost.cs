using System;
using System.Diagnostics;

namespace HotelBooking
{
    public class Cost
    {
        private Cost(double cost)
        {
            UsdCost = cost;
        }

        public double UsdCost { get; }

        public static Cost FromUsd(double usdCost)
        {
            Debug.Assert(usdCost > 0);
            return new Cost(usdCost);
        }

        #region Equals, <=, >= and hash code

        protected bool Equals(Cost other)
        {
            return Math.Abs(UsdCost - other.UsdCost) < 0.01;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Cost) obj);
        }

        public override int GetHashCode()
        {
            return UsdCost.GetHashCode();
        }

        public static bool operator <=(Cost a, Cost b)
        {
            return a.UsdCost <= b.UsdCost;
        }

        public static bool operator >=(Cost a, Cost b)
        {
            return b <= a;
        }

        #endregion
    }
}