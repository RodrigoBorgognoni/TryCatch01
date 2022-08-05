using System;
using TryCatch01.Entities;
using TryCatch01.Entities.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Room number: ");
                int room = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy):");
                DateTime checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy):");
                DateTime checkout = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(room, checkin, checkout);
                Console.Write(Environment.NewLine);
                Console.WriteLine($"Reservation {reservation}");

                Console.Write(Environment.NewLine);
                Console.WriteLine("Enter data to update the reservation: ");
                Console.Write("Check-in date (dd/MM/yyyy):");
                checkin = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy):");
                checkout = DateTime.Parse(Console.ReadLine());

                reservation = new Reservation(room, checkin, checkout);

                Console.Write(Environment.NewLine);
                Console.WriteLine($"Reservation {reservation}");
            }
            catch (DomainException e)
            {
                Console.WriteLine($"Error in reservation: {e.Message}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error in reservation: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
    }
}
