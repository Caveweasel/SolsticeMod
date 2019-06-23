using Terraria;
using Terraria.ModLoader;
using SolsticeMod.NPCs;

namespace SolsticeMod.Buffs
{
	public class Darkness : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Darkness Flames");
			Description.SetDefault("Slowly losing life and 10% reduced damage");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CavesPlayer>(mod).darkness = true;
            player.meleeDamage -= 0.1f;
            player.thrownDamage -= 0.1f;
            player.rangedDamage -= 0.1f;
            player.magicDamage -= 0.1f;
            player.minionDamage -= 0.1f;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<CavesGlobalNPC>(mod).darkness = true;
        }
    }
}
