using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class DarkSpike : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Splinter");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CursedSkull];
		}

		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 14;
			npc.damage = 25;
			npc.defense = 0;
			npc.lifeMax = 10;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.value = 0f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 10;
			aiType = NPCID.CursedSkull;
			animationType = NPCID.CursedSkull;
        }
    }
}
