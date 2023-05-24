namespace GildedRose;

public class NormalAgingItem : GuildedRoseItem
{
    public NormalAgingItem(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

    public override void UpdateQuality()
    {
        if (Item.SellIn > 0 && Item.Quality > 0)
        {
            Item.Quality = Item.Quality - 1;
        }
        base.UpdateQuality();
    }
}