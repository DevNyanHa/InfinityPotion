using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace InfinifyPotionV2.Systems;

public class INFState : GlobalItem
{
    public bool INFEnabled;
    public int INFStack;

    public override bool InstancePerEntity => true;

    public override void SaveData(Item item, TagCompound tag)
    {
        tag[nameof(INFEnabled)] = INFEnabled;
        tag[nameof(INFStack)] = INFStack;
    }

    public override void LoadData(Item item, TagCompound tag)
    {
        INFEnabled = tag.GetBool(nameof(INFEnabled));
        INFStack = tag.GetInt(nameof(INFStack));
    }
}

public class INFItem : GlobalItem
{
    public override bool InstancePerEntity => true;

    public override bool ConsumeItem(Item item, Player player)
    {
        if (item.TryGetGlobalItem(out INFState state))
        {
            if (state.INFEnabled) return false;
        }
        return base.ConsumeItem(item, player);
    }

    public override bool CanStack(Item destination, Item source)
    {
        if (destination.TryGetGlobalItem(out INFState destState) &&
                source.TryGetGlobalItem(out INFState sourceState))
        {
            if (destState.INFEnabled || sourceState.INFEnabled) return false;
        }

        return base.CanStack(destination, source);
    }
}