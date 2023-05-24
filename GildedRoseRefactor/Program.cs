using System.Collections.Generic;

namespace GildedRose
{
    class Program
    { 
        IList<Item> Items;          // leave this alone - property of the goblin in the corner
        private Inventory inventory;
        
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program();

            app.inventory = new Inventory();
            app.Items = app.inventory.Items;
            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            inventory.UpdateQuality();
        }
    }
}
