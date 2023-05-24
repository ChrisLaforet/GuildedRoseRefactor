namespace GildedRose;

public class Inventory
{
    private IList<GuildedRoseItem> inventory = new List<GuildedRoseItem>();

    public Inventory()
    {
        inventory.Add(new NormalAgingItem("+5 Dexterity Vest", 10, 20));
        inventory.Add(new ImprovingQualityItem("Aged Brie", 2, 0));
        inventory.Add(new DoubleAgingAfterSellInItem("Elixir of the Mongoose", 5, 7));
        inventory.Add(new NonAgingItem("Sulfuras, Hand of Ragnaros", 0, 80));
        inventory.Add(new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 15, 20));
        inventory.Add(new NormalAgingItem("Conjured Mana Cake", 3, 6));
    }

    public IList<Item> Items
    {
        get
        {
            var items = new List<Item>();       // supports the goblin's interpretation of our inventory
            foreach (var current in inventory)
            {
                items.Add(current.Item);
            }
            return items;
        }
    }

    public Item? FindItem(string name)
    {
        return Items.FirstOrDefault(item => item.Name.Equals(name));
    }

    public void UpdateQuality()
    {
        foreach (GuildedRoseItem item in inventory)
        {
            item.UpdateQuality();
        }
    }
}