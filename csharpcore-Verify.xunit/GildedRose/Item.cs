
namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public bool IsLegendary => Name == "Sulfuras, Hand of Ragnaros";
        public bool IsConcert => Name == "Backstage passes to a TAFKAL80ETC concert";
        public bool IsAgedBrie => Name == "Aged Brie";
        public bool NotIncreasesPassesTime => !IsAgedBrie && !IsConcert;
        public bool QualityIsNotNegative => Quality > 0;
        public bool QualityIsBelow50 => Quality < 50;
    }
}
