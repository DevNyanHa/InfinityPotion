using InfinifyPotionV2.Systems;
using System;
using System.ComponentModel;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace InfinifyPotionV2;

public enum ActivationMethod
{
    /*Auto,*/
    Select,
}

[BackgroundColor(41, 31, 48, 216)]
public class MainConfig : ModConfig
{
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("InfinityItem")]

    [BackgroundColor(117, 31, 191, 192)]
    [DefaultValue(true)]
    public bool Enabled;

    [BackgroundColor(117, 31, 191, 192)]
    [DefaultValue(ActivationMethod.Select)]
    public ActivationMethod ActivationMethod;

    [BackgroundColor(117, 31, 191, 192)]
    [DefaultValue(3996)]
    [Range(0, 9999)]
    [Increment(1)]
    public int MinimumCondition;

    /*[BackgroundColor(117, 31, 191, 192)]
    [DefaultValue(false)]
    public bool InfiniteEffect;*/

    public override void OnChanged()
    {
        if (Enabled) return;

        foreach (Item item in Main.LocalPlayer.inventory)
        {
            if (item.IsAir) continue;

            if (item.TryGetGlobalItem(out INFState state))
            {
                state.INFEnabled = false;

                if (state.INFStack > 0)
                {
                    item.stack = state.INFStack;
                }
            }
        }
    }
}

public class INFConfig
{
    public static MainConfig Config => ModContent.GetInstance<MainConfig>();
}