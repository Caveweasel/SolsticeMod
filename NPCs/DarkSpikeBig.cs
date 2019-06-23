using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class DarkSpikeBig : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Spike");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CursedSkull];
		}

		public override void SetDefaults()
		{
			npc.width = 16;
			npc.height = 14;
			npc.damage = 30;
			npc.defense = 6;
			npc.lifeMax = 40;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.value = 0f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 10;
			aiType = NPCID.CursedSkull;
			animationType = NPCID.CursedSkull;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var p = spawnInfo.player.GetModPlayer<CavesPlayer>(mod);

            if (CavesWorld.downedDarkMon == true && p.darkIncense == true)
            {
                return SpawnCondition.Overworld.Chance * 0.2f;
            }

            else
            {
                return 0f;
            }

        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            var p = player.GetModPlayer<CavesPlayer>(mod);
            if (Main.expertMode)
            {
                if (mod.BuffType("Darkness") >= 0 && p.dreamShield == false)
                {
                    player.AddBuff(mod.BuffType("Darkness"), 180, true);
                    player.AddBuff(BuffID.Blackout, 180, true);
                }
            }
            else
            {
                if (Main.rand.Next(2) == 0)
                {
                    if (mod.BuffType("Darkness") >= 0 && p.dreamShield == false)
                    {
                        player.AddBuff(mod.BuffType("Darkness"), 180, true);
                        player.AddBuff(BuffID.Darkness, 180, true);
                    }
                }
            }
        }
    }
}
