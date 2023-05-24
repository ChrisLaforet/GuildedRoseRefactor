namespace GildedRose;

public class BackstagePassItem : GuildedRoseItem
{
    public BackstagePassItem(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

    public override void UpdateQuality()
    {
        var newQuality = Item.SellIn switch
        {
            >10 => Item.Quality + 1,
            <=10 and >5 => Item.Quality + 2,
            <=5 and >0 => Item.Quality + 3,
            <=0 => 0
        };
        Item.Quality = newQuality > GuildedRoseItem.MaxQuality ? GuildedRoseItem.MaxQuality : newQuality;
        base.UpdateQuality();
    }
}