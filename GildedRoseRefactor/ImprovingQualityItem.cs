namespace GildedRose;

public class ImprovingQualityItem : GuildedRoseItem
{
    public ImprovingQualityItem(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

    public override void UpdateQuality()
    {
        if (Item.Quality < GuildedRoseItem.MaxQuality)
        {
            Item.Quality = Item.Quality + 1;
        }
        base.UpdateQuality();
    }
}