using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace InfinifyPotionV2;

public class INFMessage : ModPlayer
{
    private bool entred = false;

    public override void OnEnterWorld()
    {
        if (entred) return;

        if (Main.netMode == NetmodeID.Server) return;

        float t = (float)Main.timeForVisualEffects * 0.02f;

        Main.NewText(
            "InfinityPotion V2 - v1.0.0",
            Color.Lerp(
                Color.Purple,
                Color.Blue,
                (MathF.Sin(t) + 1f) / 2f
            )
        );


        entred = true;
    }

    public override void SaveData(TagCompound tag)
    {
        tag["INFentred"] = entred;
    }

    public override void LoadData(TagCompound tag)
    {
        entred = tag.GetBool("INFentred");
    }
}
