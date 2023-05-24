namespace GildedRose;

public class DoubleAgingAfterSellInItem : NormalAgingItem
{
    public DoubleAgingAfterSellInItem(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

    public override void UpdateQuality()
    {
        base.UpdateQuality();
        if (Item.SellIn <= 0)
        {
            Item.Quality = Item.Quality - 2;
        }
    }
}