using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace InfinityPotion
{
    public class InfinityTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            var config = ModContent.GetInstance<MainConfig>();

            if (InfinityPotion.getItemType(item)!=ItemType.NotConsume)
            {
                TooltipLine line = new TooltipLine(Mod, "InfinityTooptip", "[Infinity]");
                Color color;
                {
                    float t = (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 1.5) * 0.5 + 0.5);

                    color = Color.Lerp(Color.DarkOrchid, Color.DarkSlateBlue, t);
                    color = Color.Lerp(color, Color.Fuchsia, t / 5);
                    color = Color.Lerp(color, Color.Black, 0.1f);

                    line.OverrideColor = color;
                }
                tooltips.Insert(1, line);
            }
        }
    }
}
