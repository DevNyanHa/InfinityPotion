using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace InfinityPotion
{
    public class InfinityTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var config = ModContent.GetInstance<MainConfig>();

            bool isInfinite = false;

            if (config.Potion && (item.buffType > 0 || item.healLife > 0 || item.healMana > 0))
                isInfinite = true;
            if (config.Other)
                isInfinite = true;

            if (isInfinite)
            {
                TooltipLine line = new TooltipLine(Mod, "InfinityTooptip", "[Infinity]");
                line.OverrideColor = new Color(105, 105, 105);
                tooltips.Add(line);
            }
        }
    }
}