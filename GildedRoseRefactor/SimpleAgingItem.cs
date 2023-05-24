namespace GildedRose;

public class SimpleAgingItem : GuildedRoseItem
{
    protected int rate;

    public SimpleAgingItem(string name, int sellIn, int quality, int rate = 1) : base(name, sellIn, quality)
    {
        this.rate = rate;
    }

    public override void UpdateQuality()
    {
        if (Item.SellIn > 0 && Item.Quality > 0)
        {
            var newQuality = Item.Quality - rate;
            Item.Quality = newQuality < 0 ? 0 : newQuality;
        }
        base.UpdateQuality();
    }
}