namespace GildedRose;

public abstract class GuildedRoseItem
{
    public const int MaxQuality = 50;
    
    public Item Item { get; protected set; }

    public virtual void UpdateQuality()
    {
        Item.SellIn = Item.SellIn - 1;
    }

    public GuildedRoseItem(string name, int sellIn, int quality)
    {
        this.Item = new Item()
        {
            Name = name,
            Quality = quality,
            SellIn = sellIn
        };
    }
}