using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteWorkshop.HouseAndTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var houseStart = 1;
            var houseEnd = 5;
            var appleTreePosition = 2;
            var orangeTreePosition = 4;

            var droppedApplesLocations = new List<int> { -2, -5, 4 };
            var droppedOrangeLocations = new List<int> { -1, 2, 5, -4 };

            var totalHittedApple = droppedApplesLocations.Where(al =>
                (appleTreePosition + al) >= houseStart &&
                (appleTreePosition + al) <= houseEnd).Count();

            var totalHittedOrange = droppedOrangeLocations.Where(al =>
                (orangeTreePosition + al) >= houseStart &&
                (orangeTreePosition + al) <= houseEnd).Count();

            Console.WriteLine("Hitted Apple Count : " + totalHittedApple);
            Console.WriteLine("Hitted Orange Count : " + totalHittedOrange);

            Console.Write("Kapatmak için bir tuşa basınız...");
            Console.ReadKey();
        }
    }
}
