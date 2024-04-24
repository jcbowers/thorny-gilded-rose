using System.Data.SqlClient;

namespace Api.GildedRose.Dmi
{
    internal class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;

                            var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                            conn.Open();

                            var cmd = conn.CreateCommand();
                            cmd.CommandText = $"update items set Quality = {Items[i].Quality} where ItemId = {Items[i].ItemId}";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;

                                    var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                                    conn.Open();

                                    var cmd = conn.CreateCommand();
                                    cmd.CommandText = $"update items set Quality = {Items[i].Quality} where ItemId = {Items[i].ItemId}";
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;

                                    var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                                    conn.Open();

                                    var cmd = conn.CreateCommand();
                                    cmd.CommandText = $"update items set Quality = {Items[i].Quality} where ItemId = {Items[i].ItemId}";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;

                    var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                    conn.Open();

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = $"update items set SellIn = {Items[i].SellIn} where ItemId = {Items[i].ItemId}";
                    cmd.ExecuteNonQuery();
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;

                                    var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                                    conn.Open();

                                    var cmd = conn.CreateCommand();
                                    cmd.CommandText = $"update items set Quality = {Items[i].Quality} where ItemId = {Items[i].ItemId}";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;

                            var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                            conn.Open();

                            var cmd = conn.CreateCommand();
                            cmd.CommandText = $"update items set Quality = {Items[i].Quality} where ItemId = {Items[i].ItemId}";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;

                            var conn = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=Storage.GildedRose.Dmi;User ID=WebUser;password=foobar;Connect Timeout=30;");
                            conn.Open();

                            var cmd = conn.CreateCommand();
                            cmd.CommandText = $"update items set Quality = {Items[i].Quality} where ItemId = {Items[i].ItemId}";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
