using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.NotIncreasesPassesTime && item.QualityIsNotNegative && !item.IsLegendary)
                    item.Quality--;

                if(!item.NotIncreasesPassesTime && item.QualityIsBelow50)
                {
                    item.Quality++;

                    if (item.IsConcert)
                        CaculateQualityIncreasingForConcert(item);
                }

                if (!item.IsLegendary)
                    item.SellIn--;

                if (item.SellIn >= 0)
                    continue;

                if (!item.IsAgedBrie)
                {
                    if (!item.IsConcert && item.QualityIsNotNegative && !item.IsLegendary)
                        item.Quality--;
                    
                    if(item.IsConcert)
                        item.Quality = 0;
                }

                if(item.IsAgedBrie && item.QualityIsBelow50)
                    item.Quality++;
            }
        }

        private static void CaculateQualityIncreasingForConcert(Item item)
        {
            if(!item.QualityIsBelow50) return;

            if (item.SellIn <= 10)
                item.Quality++;

            if (item.SellIn <= 5)
                item.Quality++;
        }
    }
}
