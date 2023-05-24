using GildedRose;

namespace GuildedRoseTests;

public class InventoryTests
{
    [Fact]
    public void GivenNothing_WhenCreatingInventory_ThenInventoryContainsItems()
    {
        var inventory = new Inventory();
        Assert.True(inventory.Items.Count > 0);
    }

    [Fact]
    public void GivenInventory_WhenOneUpdateQuality_ThenElixirOfTheMongooseQualityAges()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Elixir of the Mongoose");
        var initialQuality = item.Quality;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality - 1, item.Quality);
    }

    [Fact]
    public void GivenInventory_WhenUpdateQuality_ThenSulfurasDoesNotAge()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Sulfuras, Hand of Ragnaros");
        var initialQuality = item.Quality;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQuality_ThenAgedBrieQualityIncreases()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Aged Brie");
        var initialQuality = item.Quality;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 1, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityWithSellInGreaterThan10_ThenBackstagePassesQualityIncreasesBy1()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Backstage passes to a TAFKAL80ETC concert");
        var initialQuality = item.Quality;
        item.SellIn = 11;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 1, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityWithSellInLessThan10_ThenBackstagePassesQualityIncreasesBy2()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Backstage passes to a TAFKAL80ETC concert");
        var initialQuality = item.Quality;
        item.SellIn = 9;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 2, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityWithSellIs10_ThenBackstagePassesQualityIncreasesBy2()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Backstage passes to a TAFKAL80ETC concert");
        var initialQuality = item.Quality;
        item.SellIn = 9;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 2, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityWithSellInExpired_ThenBackstagePassesQualityIsZero()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Backstage passes to a TAFKAL80ETC concert");
        item.SellIn = 0;
        inventory.UpdateQuality();
        Assert.Equal(0, item.Quality);
    }
}
