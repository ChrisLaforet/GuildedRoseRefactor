namespace GildedRose;

public class DoubleAgingAfterSellInItem : SimpleAgingItem
{
    public DoubleAgingAfterSellInItem(string name, int sellIn, int quality) : base(name, sellIn, quality) {}

    public override void UpdateQuality()
    {
        base.UpdateQuality();
        if (Item.SellIn <= 0)
        {
            var newQuality = Item.Quality - (base.rate * 2);
            Item.Quality = newQuality >= 0 ? newQuality : 0;
        }
    }
}