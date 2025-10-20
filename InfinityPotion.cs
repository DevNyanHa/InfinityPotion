using Terraria;
using Terraria.ModLoader;

namespace InfinityPotion
{
    public enum ItemType
    {
        Potion,
        Summon,
        Ammo,
        Favorites,
        Other,
        NotConsume
    }

    public class InfinityPotion : Mod
	{
        public static ItemType getItemType(Item item)
        {
            var config = ModContent.GetInstance<MainConfig>();

            if (!item.consumable)
                return ItemType.NotConsume;

            if (config.Favorites)
                return (item.favorited) ? ItemType.Favorites : ItemType.NotConsume;

            if (item.useStyle == Terraria.ID.ItemUseStyleID.DrinkLiquid)
                return (config.Potion) ? ItemType.Potion : ItemType.NotConsume;

            if (item.ammo > 0)
                return (config.Ammo) ? ItemType.Ammo : ItemType.NotConsume;

            return (config.Other) ? ItemType.Other : ItemType.NotConsume;
        }
	}
}