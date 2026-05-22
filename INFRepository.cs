namespace InfinifyPotionV2;

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

public class INFRepository : ModSystem
{
    public static HashSet<int> INFPotions = [];

    public override void PostSetupContent()
    {
        INFPotions.Clear();

        for (int i = 0; i < ItemLoader.ItemCount; i++)
        {
            Item item = new();
            item.SetDefaults(i);

            if (item.buffType > 0 && item.consumable)
            {
                INFPotions.Add(i);
            }
        }
    }
}