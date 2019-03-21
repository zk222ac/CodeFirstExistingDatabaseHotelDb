using System;
using System.Linq;
using CodeFirstExistingDatabaseHotelDb.EFModels;

namespace CodeFirstExistingDatabaseHotelDb
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            using (var db = new HotelDbContext())
            {
                // PART A
               
                Console.WriteLine("List all information about all hotels ");
                var allhotels = from h in db.Hotels
                    select h;
                Print(allhotels);
                Console.WriteLine(".............................................................................");

                Console.WriteLine("List all information about all hotels in Roskilde ");
                var allhotelsInRoskilde = from h in db.Hotels
                    where h.Address.Contains("Roskilde")
                    select h;
                Print(allhotelsInRoskilde);
                Console.WriteLine("..............................................................................");
                Console.WriteLine("List all double rooms with a price below 300 pr. night. ");
                var allDoubleRoomsPriceLessThan300 = from h in db.Rooms
                    where h.Types.Contains("D") && h.Price < 300
                    select h;
                Print(allDoubleRoomsPriceLessThan300);
                Console.WriteLine("..............................................................................");
                Console.WriteLine("List all double or family rooms with a price below 400 pr. night");

                var allDoubleOrFamilyRoomsPriceLessThan400 = from h in db.Rooms
                    where ((h.Types.Contains("D") || h.Types.Contains("F")) && h.Price < 400)
                    orderby h.Price descending
                    select h;
                Print(allDoubleOrFamilyRoomsPriceLessThan400);
                Console.WriteLine("..............................................................................");

                Console.WriteLine("List all double or family rooms with a price Greater than 400 pr. night");

                var allDoubleOrFamilyRoomsPriceGreaterThan400 = from h in db.Rooms
                    where ((h.Types.Contains("D") || h.Types.Contains("F")) && h.Price > 400)
                    orderby h.Price descending
                    select h;
                Print(allDoubleOrFamilyRoomsPriceGreaterThan400);
                Console.WriteLine("..............................................................................");

                Console.WriteLine("List all guests who have a name starting with 'G' ");

                var allGuestNameStartWithG = from h in db.Guests
                    where h.Name.StartsWith("G")
                    select h;
                Print(allGuestNameStartWithG);
                Console.WriteLine("..............................................................................");

                // PART B
                
              
                
                //How many bookings are there at Scandic hotel tomorrow ?

               Console.WriteLine("How many hotels are there? ");

                var allHotelsCount = from h in db.Hotels
                                     select h;
                Console.WriteLine($"There are {allHotelsCount.Count()} hotels ");
                Console.WriteLine("..............................................................................");

                Console.WriteLine("How many hotels are there in Roskilde? ");
                var allHotelsCountInRoskilde = from h in db.Hotels
                    where h.Address.Contains("Roskilde") 
                    select h;
                Console.WriteLine($"There are {allHotelsCountInRoskilde.Count()} hotels in Roskilde ");
                Console.WriteLine("..............................................................................");

                Console.WriteLine("What is the average price of a single room");
                var avgPriceSingleRoom = from h in db.Rooms
                    where h.Types == "S"
                    select h.Price;
                Console.WriteLine($"average price of a single room is {avgPriceSingleRoom.Average()}  ");
                // alternative way .................................
                //var avgPriceSingleRoom = from h in db.Rooms
                //    where h.Types == "S"
                //    select h;
                //Console.WriteLine($"There are {avgPriceSingleRoom.Average(p => p.Price)} hotels ");

                Console.WriteLine("..............................................................................");
                Console.WriteLine("What is the average price of a room");
                var avgPriceRoom = from h in db.Rooms
                    select h.Price;

                Console.WriteLine($"Average Price of a room {avgPriceRoom.Average()}  ");
                // alternative way .................................
                //var avgPriceRoom = from h in db.Rooms select h;
                //Console.WriteLine($"There are {avgPriceRoom.Average(p => p.Price)} hotels ");

                Console.WriteLine("..............................................................................");
                Console.WriteLine("What is the average price of a Double room");
                var avgPriceDoubleRoom = from h in db.Rooms
                    where h.Types == "D"
                    select h.Price;
                Console.WriteLine($"Average price of a Double Room {avgPriceDoubleRoom.Average()} ");
                Console.WriteLine("..............................................................................");

                Console.WriteLine("..............................................................................");
                Console.WriteLine("What is the average price of a room at Hotel Scandic?");
                var avgPriceRoomHotelScandic = from r in db.Rooms
                    where r.Hotel.Name.Contains("Scandic")
                    select r;
                Print(avgPriceRoomHotelScandic);
                Console.WriteLine($"The average price of a room at hotel is {avgPriceRoomHotelScandic.Average(p => p.Price)}  ");

                Console.WriteLine("..............................................................................");
                Console.WriteLine("What is the total income per night for all double rooms ?");
                var totalIncomePerNightDoubleRoom = from h in db.Rooms
                    where h.Types == "D"
                    select h;
                Print(avgPriceRoomHotelScandic);
                Console.WriteLine($"There are {totalIncomePerNightDoubleRoom.Sum(p => p.Price)} Total income per night for all double rooms ");

                Console.WriteLine("..............................................................................");
                Console.WriteLine("How many different guests have made bookings in March");
                var guestBookingInMarch = from b in db.Bookings where (b.DateFrom.Month == 3 || b.DateTo.Month == 3) select b;
                Print(guestBookingInMarch);
                Console.WriteLine("Guest count in March: " + guestBookingInMarch.Count());
                Console.WriteLine("...........................................................");

                Console.WriteLine("How many bookings are there today at Scandic hotel ?");
                var todayBookingScandicHotel = from b in db.Bookings
                    where b.DateFrom < DateTime.Now && b.DateTo > DateTime.Now
                    //where b.Room.Hotel.Name.Contains("Scandic")
                    select b;
                
                Print(todayBookingScandicHotel);
                Console.WriteLine("Bookings on Today dates at scandic hotel: " + todayBookingScandicHotel.Count());
                Console.WriteLine("...........................................................");

                Console.WriteLine("How many bookings are there at Scandic hotel tomorrow");
                DateTime tomorrow = DateTime.Now.AddDays(1); 
                var tomorrowBookingScandicHotel = from b in db.Bookings
                    where b.DateFrom < tomorrow && b.DateTo > tomorrow
                    select b;

                Print(tomorrowBookingScandicHotel);
                Console.WriteLine("Bookings on tomorrow dates at scandic hotel: " + tomorrowBookingScandicHotel.Count());
                Console.WriteLine("...........................................................");

                    
            }

            Console.ReadKey();
        }

       public static void Print(dynamic items)
       {
           foreach (var item in items)
           {
               Console.WriteLine(item);
           }
       }
    }

    
}
