using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class DarknessPiranha : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Piranha");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
		}

		public override void SetDefaults()
		{
			npc.width = 34;
			npc.height = 22;
			npc.damage = 26;
			npc.defense = 3;
			npc.lifeMax = 80;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            npc.value = 100f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 2;
			aiType = NPCID.Piranha;
			animationType = NPCID.DemonEye;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            var p = spawnInfo.player.GetModPlayer<CavesPlayer>(mod);

            if (CavesWorld.downedDarkMon == true && p.darkIncense == true)
            {
                return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
            }
            else
            {
                if (CavesWorld.downedDarkMon == true)
                {
                    return SpawnCondition.OverworldNightMonster.Chance * 0.05f;
                }

                else
                {
                    return 0f;
                }
            }
		}
       public override void NPCLoot()  //Npc drop
        {
			//if(Main.rand.Next(1,3)==1)
            //{
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessDrop"), 1 + Main.rand.Next(2)); //Item spawn
                                                                                                  //}
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
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            var p = player.GetModPlayer<CavesPlayer>(mod);
            if (Main.expertMode)
            {
                if (Main.rand.Next(3) == 0)
                {
                    if (mod.BuffType("Darkness") >= 0 && p.dreamShield == false)
                    {
                        player.AddBuff(mod.BuffType("Darkness"), 90, true);
                    }
                }
            }
        }
	}
}
