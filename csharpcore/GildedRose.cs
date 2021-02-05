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
                if (!Items[i].Name.Equals(ConstantName.AgedBrie) 
                    && !Items[i].Name.Equals(ConstantName.BackStagePasses) 
                    && !Items[i].Name.Equals(ConstantName.SulfurasHandOfRagnaros) 
                                            && Items[i].Quality > 0)
                {
                    Items[i].Quality = Items[i].Quality - 1;
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name.Equals(ConstantName.BackStagePasses))
                        {
                            if (Items[i].SellIn < 11 && Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }

                            if (Items[i].SellIn < 6 && Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }

                if (!Items[i].Name.Equals(ConstantName.SulfurasHandOfRagnaros))
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (!Items[i].Name.Equals(ConstantName.AgedBrie))
                    {
                        if (!Items[i].Name.Equals(ConstantName.BackStagePasses))
                        {
                            if (Items[i].Quality > 0 && !Items[i].Name.Equals(ConstantName.SulfurasHandOfRagnaros))
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }

    public static class ConstantName
    {
        public static string AgedBrie = "Aged Brie";
        public static string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        public static string BackStagePasses = "Backstage passes to a TAFKAL80ETC concert";
    }
}
