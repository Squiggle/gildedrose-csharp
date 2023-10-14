using GildedRose;
using System.Collections.Generic;

namespace GildedRose.Tests;

public class GildedRoseTests
{
    [Fact]
    public void UpdateQuality_DecreasesQualityByOne()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(9, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_DecreasesSellInByOne()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(9, items[0].SellIn);
    }

    [Fact]
    public void UpdateQuality_DoesNotDecreaseQualityBelowZero()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_IncreasesQualityOfAgedBrie()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(11, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_DoesNotIncreaseQualityAboveFifty()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(50, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_IncreasesQualityOfBackstagePasses()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(11, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_IncreasesQualityOfBackstagePassesByTwoWhenSellInIsTenOrLess()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(12, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_IncreasesQualityOfBackstagePassesByThreeWhenSellInIsFiveOrLess()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(13, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_DropsQualityOfBackstagePassesToZeroAfterTheConcert()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void UpdateQuality_DoesNotChangeQualityOfSulfuras()
    {
        // Arrange
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        var gildedRose = new GildedRose(items);

        // Act
        gildedRose.UpdateQuality();

        // Assert
        Assert.Equal(80, items[0].Quality);
    }
}
