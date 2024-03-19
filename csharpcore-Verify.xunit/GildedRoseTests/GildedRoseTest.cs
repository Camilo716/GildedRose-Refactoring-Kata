using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void SellInDayReducesPassingTheDays()
        {
            List<Item> Items = [ new Item { Name = "foo", SellIn = 10, Quality = 0 }];
            GildedRose app = new(Items);

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.Equal(7, Items[0].SellIn);
        }

        [Fact]
        public void QualityReducesPassingTheDays()
        {
            List<Item> Items = [ new Item { Name = "foo", SellIn = 10, Quality = 4 }];
            GildedRose app = new(Items); 

            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality();

            Assert.Equal(1, Items[0].Quality);
        }

        [Fact]
        public void OnceSellDatePassedQualityDegradesTwiceAsFast()
        {
            List<Item> Items = [ new Item { Name = "foo", SellIn = 1, Quality = 6 }];
            GildedRose app = new(Items);         
            
            app.UpdateQuality();
            app.UpdateQuality();
            app.UpdateQuality(); 
        
            Assert.Equal(1, Items[0].Quality);
        }
    }
}
