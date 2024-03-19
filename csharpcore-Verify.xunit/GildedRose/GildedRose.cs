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

                if(!item.NotIncreasesPassesTime)
                {
                    if (item.QualityIsLessThan50)
                    {
                        item.Quality++;

                        if (item.IsConcert)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.QualityIsLessThan50)
                                    item.Quality++;
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.QualityIsLessThan50)
                                    item.Quality++;
                            }
                        }
                    }
                }

                if (!item.IsLegendary)
                    item.SellIn--;

                if (item.SellIn < 0)
                {
                    if (!item.IsAgedBrie)
                    {
                        if (!item.IsConcert)
                        {
                            if (item.QualityIsNotNegative)
                            {
                                if (!item.IsLegendary)
                                    item.Quality--;
                            }
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (item.QualityIsLessThan50)
                            item.Quality++;
                    }
                }
            }
        }
    }
}
