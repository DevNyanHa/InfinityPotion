using Terraria;
using Terraria.ModLoader;

namespace InfinityPotion
{
    public class InfinityItem : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            var config = ModContent.GetInstance<MainConfig>();

            if (InfinityPotion.getItemType(item) == ItemType.NotConsume)
            {
                return true;
            }
            return false;
        }

        public override bool CanConsumeAmmo(Item weapon, Item ammo, Player player)
        {
            var config = ModContent.GetInstance<MainConfig>();

            if (InfinityPotion.getItemType(ammo) == ItemType.NotConsume)
                return true;
            return false;
        }
    }
}
