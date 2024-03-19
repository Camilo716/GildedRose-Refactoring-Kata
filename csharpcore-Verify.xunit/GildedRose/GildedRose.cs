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
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.QualityIsBelow50)
                                item.Quality++;
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.QualityIsBelow50)
                                item.Quality++;
                        }
                    }
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
    }
}
