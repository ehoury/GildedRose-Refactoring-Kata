using System.Collections.Generic;

namespace csharpcore
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
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                if (!item.Name.Equals(ConstantName.AgedBrie) 
                    && !item.Name.Equals(ConstantName.BackStagePasses) 
                    && !item.Name.Equals(ConstantName.SulfurasHandOfRagnaros) 
                                            && item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
                else
                {
                    HandleLowerQuality(item);
                }

                if (!item.Name.Equals(ConstantName.SulfurasHandOfRagnaros))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!item.Name.Equals(ConstantName.AgedBrie))
                    {
                        if (!item.Name.Equals(ConstantName.BackStagePasses))
                        {
                            if (item.Quality > 0 && !item.Name.Equals(ConstantName.SulfurasHandOfRagnaros))
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        HandleLowerQuality(item);
                    }
                }
            }
        }

        private static void HandleLowerQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                if (item.Name.Equals(ConstantName.BackStagePasses) &&
                    item.Quality < 50)
                {
                    if (item.SellIn < 11)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    if (item.SellIn < 6)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}
