using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace InfinifyPotionV2.Systems;

public class INFCursor : ModSystem
{
    public override void PostDrawInterface(SpriteBatch spriteBatch)
    {
        if (!INFConfig.Config.Enabled) return;
        if (!((INFToggle.INFToggleKey?.Current ?? false)
        && Main.playerInventory)) return;

        Main.cursorOverride = -1;

        Texture2D texture = ModContent.Request<Texture2D>("InfinifyPotionV2/Systems/CursorEffect").Value;

        Vector2 pos = Main.MouseScreen - new Vector2(2f, 2f);

        float t = Main.GlobalTimeWrappedHourly * 2.5f;

        float scale = t - (int)t;

        spriteBatch.Draw(
            texture,
            pos,
            null,
            Color.White,
            0f,
            texture.Size() / 2f,
            scale,
            SpriteEffects.None,
            0f
        );
    }
}

public class INFToggle : ModSystem
{
    public static ModKeybind INFToggleKey { get; private set; }

    public override void Load()
    {
        INFToggleKey = KeybindLoader.RegisterKeybind(Mod, "Toggle Infinite Potion", Keys.OemTilde);
    }

    public override void Unload()
    {
        INFToggleKey = null;
    }
}

public class INFClick : ModPlayer
{
    public override bool HoverSlot(Item[] inventory, int context, int slot)
    {
        if (!INFConfig.Config.Enabled) return false;

        if (INFToggle.INFToggleKey == null || !INFToggle.INFToggleKey.Current) return false;

        if (!Main.mouseLeft || !Main.mouseLeftRelease) return true;

        Item clickedItem = inventory[slot];

        Main.mouseLeftRelease = false;

        if (!INFRepository.INFPotions.Contains(clickedItem.type)) return true;

        if (clickedItem.TryGetGlobalItem(out INFState state))
        {
            if (clickedItem.stack < INFConfig.Config.MinimumCondition && !state.INFEnabled) return true;

            state.INFEnabled = !state.INFEnabled;

            if (state.INFEnabled)
            {
                SoundEngine.PlaySound(SoundID.DD2_DarkMageHealImpact, Player.Center);
                state.INFStack = clickedItem.stack;
                clickedItem.stack = 1;
            }
            else
            {
                clickedItem.stack = state.INFStack;
            }
        }

        return true;
    }
}
