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
        inventory.UpdateQuality();
        Assert.Equal(6, item.Quality);
    }
}
