using System.Collections.Generic;

namespace GildedRose
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var inventory = new Inventory(); 
            inventory.UpdateQuality();

            System.Console.ReadKey();
        }
    }
}
