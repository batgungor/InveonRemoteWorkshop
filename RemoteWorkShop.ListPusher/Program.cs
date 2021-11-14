using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteWorkShop.ListPusher
{
    class Program
    {
        private static List<StoredData> List = new List<StoredData>();
        static void Main(string[] args)
        {
            /*
             -> batuhan -> batuhan1
             -> batuhan -> batuhan2
             -> batuhan -> batuhan30000000000
             -> berkan -> berkan1
             -> emre -> emre1
             -> sil batuhan2 -> ok
             -> batuhan -> batuhan2   add batuhan
             */

            while (true)
            {
                var word = Console.ReadLine();
                var splittedList = word.Split(" ");
                if (splittedList[0] == "add")
                {
                    Console.WriteLine(Add(splittedList[1]));
                }
                else if (splittedList[0] == "del")
                {
                    Console.WriteLine(Delete(splittedList[1]));
                }
                else
                {
                    break;
                }
            }

            Console.Write("Kapatmak için bir tuşa basınız...");
            Console.ReadKey();
        }

        private static string Add(string word)
        {
            var data = List.Where(q => q.Word == word).FirstOrDefault();
            if (data != null)
            {
                if (data.DeletedIndexes.Any())
                {
                    var index = data.DeletedIndexes.OrderBy(q => q).FirstOrDefault();
                    data.DeletedIndexes.Remove(index);
                    return data.Word + index;
                }
                else
                {
                    data.LastIndex++;
                }
            }
            else
            {
                data = new StoredData()
                {
                    Word = word
                };
                List.Add(data);
            }
            return data.Word + data.LastIndex;
        }

        private static int Delete(string word)
        {
            var response = 1;
            var data = List.Where(q => word.Contains(q.Word)).FirstOrDefault();
            if (data != null)
            {
                var index = Convert.ToInt32(word.Replace(data.Word, "")); //batuhan1,batuhan -> 1 ->int 1
                if (index > data.LastIndex && data.DeletedIndexes.Any(q=> q == index))
                {
                    response = 1;
                }
                else
                {
                    data.DeletedIndexes.Add(index);
                    response = 0;
                }
            }
            return response;
        }
    }

    public class StoredData
    {
        public StoredData()
        {
            LastIndex = 1;
            DeletedIndexes = new List<int>();
        }
        public string Word { get; set; }
        public int LastIndex { get; set; }
        public List<int> DeletedIndexes { get; set; }
    }
}
