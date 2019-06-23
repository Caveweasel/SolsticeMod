using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class DarknessEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Eye");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
		}

		public override void SetDefaults()
		{
			npc.width = 34;
			npc.height = 22;
			npc.damage = 18;
			npc.defense = 2;
			npc.lifeMax = 60;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 2;
			aiType = NPCID.DemonEye;
			animationType = NPCID.DemonEye;
            //banner = npc.type;
            //bannerItem = mod.ItemType("DarknessEye");
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            var p = spawnInfo.player.GetModPlayer<CavesPlayer>(mod);

            if (p.darkIncense == true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
            }

            return SpawnCondition.OverworldNightMonster.Chance * 0.1f;
		}
       public override void NPCLoot()  //Npc drop
        {
			if(Main.rand.Next(3) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessDrop"), 1); //Item spawn
			}
		}
		//public override void HitEffect(int hitDirection, double damage)
		//{
			//for (int i = 0; i < 10; i++)
			//{
				//int dustType = Main.rand.Next(139, 143);
				//int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				//Dust dust = Main.dust[dustIndex];
				//dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				//dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				//dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			//}
		//}
	}
}
