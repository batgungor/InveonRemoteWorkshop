using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteWorkshop.CrazySunday
{
    class Program
    {
        static void Main(string[] args)
        {
            var positionList = new List<int> { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1 };

            //var totalStepCount = 0;
            //for (int konum = 0; konum < positionList.Count; konum++)
            //{
            //    var maxStep = Math.Min(2, (positionList.Count - 1) - konum);// ((12-1) - 10) = 1
            //    if (positionList[konum + maxStep] == 1)
            //    {
            //        konum++;
            //    }
            //    totalStepCount++;
            //}

            string positions = string.Join("", positionList);
            var splitList = positions.Split("0");
            var longJumpCount = splitList.Length - 1;
            longJumpCount += splitList.Sum(sl => sl.Length / 2);

            Console.WriteLine("Atılan Adım Sayısı : " + longJumpCount);
            Console.Write("Kapatmak için bir tuşa basınız...");
            Console.ReadKey();
        }
    }
}
