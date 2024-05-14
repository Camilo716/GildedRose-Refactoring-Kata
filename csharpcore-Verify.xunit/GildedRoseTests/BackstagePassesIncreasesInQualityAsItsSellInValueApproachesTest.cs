using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class BackstagePassesIncreasesInQualityAsItsSellInValueApproachesTest
{
    [Fact]
    public void IncreasesBy2WhenThereAre10DaysOrLess()
    {
        List<Item> Items = [ new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 }];
        GildedRose app = new(Items);

        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();

        Assert.Equal(6, Items[0].Quality);
        Assert.Equal(7, Items[0].SellIn);
    }

    [Fact]
    public void IncreasesBy3WhenThereAre5DaysOrLess()
    {
        List<Item> Items = [ new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 }];
        GildedRose app = new(Items);

        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();

        Assert.Equal(9, Items[0].Quality);
        Assert.Equal(2, Items[0].SellIn);
    }

    [Fact]
    public void QualityDropsTo0AfterTheConcert()
    {
        List<Item> Items = [ new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 }];
        GildedRose app = new(Items);

        app.UpdateQuality();
        app.UpdateQuality();
        app.UpdateQuality();

        Assert.Equal(0, Items[0].Quality);
    }
}