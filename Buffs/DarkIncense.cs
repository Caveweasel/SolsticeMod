using Terraria;
using Terraria.ModLoader;
using SolsticeMod.NPCs;

namespace SolsticeMod.Buffs
{
    public class DarkIncense : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Dark Incense");
            Description.SetDefault("Highly increases dark monsters spawn rate, and certain enemies can spawn."
            + "\n damage decreased by 10%.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<CavesPlayer>(mod).darkIncense = true;
            player.meleeDamage -= 0.1f;
            player.thrownDamage -= 0.1f;
            player.rangedDamage -= 0.1f;
            player.magicDamage -= 0.1f;
            player.minionDamage -= 0.1f;
        }
    }
}