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
    public void GivenInventory_WhenUpdateQuality_ThenElixirOfTheMongooseQualityAges()
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
    public void GivenInventory_WhenUpdateQuality_ThenSulfurasSellInDoesNotChange()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Sulfuras, Hand of Ragnaros");
        var initialSellIn = item.SellIn;
        inventory.UpdateQuality();
        Assert.Equal(initialSellIn, item.SellIn);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityAtExpiredSellIn_ThenSulfurasDoesNotAge()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Sulfuras, Hand of Ragnaros");
        var initialQuality = item.Quality;
        item.SellIn = 0;
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
        item.SellIn = 10;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 2, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityWithSellInLessThan5_ThenBackstagePassesQualityIncreasesBy3()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Backstage passes to a TAFKAL80ETC concert");
        var initialQuality = item.Quality;
        item.SellIn = 4;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 3, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityWithSellIs5_ThenBackstagePassesQualityIncreasesBy3()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Backstage passes to a TAFKAL80ETC concert");
        var initialQuality = item.Quality;
        item.SellIn = 5;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality + 3, item.Quality);
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
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityOf50_ThenAgedBrieQualityDoesNotIncrease()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Aged Brie");
        item.Quality = 50;
        inventory.UpdateQuality();
        Assert.Equal(50, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenQualityIsZero_ThenElixirOfTheMongooseQualityDoesNotBecomeNegative()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Elixir of the Mongoose");
        item.Quality = 0;
        inventory.UpdateQuality();
        Assert.Equal(0, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQualityPastSellInDate_ThenElixirOfTheMongooseQualityAgesTwiceAsFast()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Elixir of the Mongoose");
        var initialQuality = item.Quality;
        item.SellIn = 0;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality - 2, item.Quality);
    }
    
    [Fact]
    public void GivenInventory_WhenUpdateQuality_ThenConjuredQualityAgesTwiceAsFast()
    {
        var inventory = new Inventory();
        var item = inventory.FindItem("Conjured Mana Cake");
        var initialQuality = item.Quality;
        inventory.UpdateQuality();
        Assert.Equal(initialQuality - 2, item.Quality);
    }
}
