using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfinifyPotionV2.Content.Items;

public class INFIcon : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;

        Item.maxStack = Item.CommonMaxStack;

        Item.value = 0;
        Item.rare = ItemRarityID.White;
    }
}