using Terraria;
using Terraria.ModLoader;

namespace InfinityPotion
{
    public class OverrideConsume : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            var config = ModContent.GetInstance<MainConfig>();

            //포션
            if (config.Potion && (item.buffType > 0 || item.healLife > 0 || item.healMana > 0))
                return false;

            //기타
            if (config.Other)
                return false;
            return true;
        }
    }
}