using System;
using TryCatch01.Entities.Exceptions;

namespace TryCatch01.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public Reservation()
        { 
        }

        public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;

            if (checkin < now || checkout < now)
            {
                throw new DomainException("Invalid date for Check-in");
            }

            if (checkout <= checkin)
            {
                throw new DomainException("Invalid date for Check-out");
            }

            RoomNumber = roomNumber;
            CheckIn = checkin;
            CheckOut = checkout;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkin, DateTime checkout)
        {
            DateTime now = DateTime.Now;

            if (checkin < now || checkout < now)
            {
                throw new DomainException("Invalid date for Update");
            }

            if (checkout <= checkin)
            {
                throw new DomainException("Invalid date for Check-out Update");
            }

            CheckIn = checkin;
            CheckOut = checkout;
        }

        public override string ToString()
        {
            return $"Room {RoomNumber}, Checkin: {CheckIn:dd/MM/yyyy}, Checkout: {CheckOut:dd/MM/yyyy}, {Duration()} nights";
        }
    }
}
