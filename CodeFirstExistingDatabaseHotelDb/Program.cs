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
