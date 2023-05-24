namespace GildedRose;

public class NonAgingItem : GuildedRoseItem
{
    public NonAgingItem(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

    public override void UpdateQuality()
    {
    }
}