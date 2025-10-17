using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;

namespace InfinityPotion
{
    [BackgroundColor(49, 32, 36, 216)]
    public class MainConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        //RGB -- https://github.com/CalamityTeam/CalamityModPublic

        [Header("ItemFilter")]

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]
        public bool Potion { get; set; }

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(false)]
        public bool Other { get; set; }

        [Header("Option")]

        [BackgroundColor(192, 54, 64, 192)]
        [DefaultValue(true)]
        public bool ShowTooltip { get; set; }
    }
}