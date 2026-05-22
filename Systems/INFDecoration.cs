using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace InfinifyPotionV2.Systems;

public class INFDecoration : GlobalItem
{
    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
    {
        var state = item.GetGlobalItem<INFState>();

        if (!state.INFEnabled) return;

        /*tooltips.Insert(1, new TooltipLine(Mod, "INFPotion", "[Infinity]")
        {
            OverrideColor = Color.Lerp(Color.DarkSlateBlue, Color.Gainsboro, (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 1f) * 0.5f + 0.5f))
        });*/

        for (int i = 0; i < tooltips.Count; i++)
        {
            if (tooltips[i].Name == "ItemName")
            {
                tooltips[i].Text = /*"[i:" + ModContent.ItemType<INFIcon>() + "]" +*/ tooltips[i].Text;

                tooltips[i].OverrideColor = Color.Lerp(Color.Plum, Color.MediumSlateBlue, (float)(Math.Sin(Main.GlobalTimeWrappedHourly * 1f) * 0.5f + 0.5f));
            }
            if (tooltips[i].Name == "Consumable")
            {
                tooltips.RemoveAt(i);
                i--;
            }
        }
    }

    public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
    {
        if (!item.GetGlobalItem<INFState>().INFEnabled) return true;

        if (line.Name != "ItemName") return true;

        {
            var texture = ModContent.Request<Texture2D>("InfinifyPotionV2/Systems/TooltipDeco").Value;

            Main.spriteBatch.Draw(
                texture,
                new Vector2(line.X - 22f, line.Y - 17f),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                0.075f,
                SpriteEffects.None,
                0f
            );
        }
        { // 아이템 굵기 조절
            Vector2 basePos = new Vector2(line.X, line.Y);

            Vector2[] offsets = [
                new Vector2(-2, 0),
                new Vector2(2, 0),
                new Vector2(0, -2),
                new Vector2(0, 2)
            ];

            foreach (var off in offsets)
            {
                Main.spriteBatch.DrawString(
                    FontAssets.MouseText.Value,
                    line.Text,
                    basePos + off,
                    Color.Black
                );
            }
            {
                float v = (float)Math.Sin(Main.GlobalTimeWrappedHourly * 3f);
                float eased = Math.Sign(v) * (float)Math.Pow(Math.Abs(v), 0.5f);

                Vector2[] dirs =
                [
                    new Vector2(1, 1),
                    new Vector2(-1, -1),
                    new Vector2(-1, 1),
                    new Vector2(1, -1)
                ];

                foreach (var dir in dirs)
                {
                    Main.spriteBatch.DrawString(
                        FontAssets.MouseText.Value,
                        line.Text,
                        basePos + new Vector2(12f * eased, 5f * eased) * dir,
                        Color.Black * 0.5f
                    );
                }
            }
        }
        return base.PreDrawTooltipLine(item, line, ref yOffset);
    }
}