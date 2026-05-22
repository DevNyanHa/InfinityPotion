using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace InfinifyPotionV2;

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

            bool isBuffPotion =
                item.buffType > 0 &&
                item.consumable;

            bool isHealPotion =
                item.healLife > 0 &&
                item.consumable;

            bool isManaPotion =
                item.healMana > 0 &&
                item.consumable;

            if (isBuffPotion || isHealPotion || isManaPotion)
            {
                INFPotions.Add(i);
            }
        }
    }
}