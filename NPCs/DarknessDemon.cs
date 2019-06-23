using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class DarknessDemon : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Demon");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Demon];
		}

		public override void SetDefaults()
		{
			npc.width = 110;
			npc.height = 90;
			npc.damage = 36;
			npc.defense = 6;
			npc.lifeMax = 200;
			npc.HitSound = SoundID.NPCHit21;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 2;
			aiType = NPCID.Demon;
			animationType = NPCID.Demon;
            npc.buffImmune[24] = true;
            npc.buffImmune[31] = true;
            npc.buffImmune[39] = true;
            npc.buffImmune[153] = true;
            npc.lavaImmune = true;
            //banner = npc.type;
            //bannerItem = mod.ItemType("DarknessEye");
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            var p = spawnInfo.player.GetModPlayer<CavesPlayer>(mod);
            if (CavesWorld.downedDarkMon == true)
            //if(mod.NPCType("DarknessMonster").downed) //(NPC.AnyNPCs(mod.NPCType("DarknessMonster")))
            {
                return SpawnCondition.Underworld.Chance * 0.05f;
            }

            if (CavesWorld.downedDarkMon == true && p.darkIncense == true)
            {
                return SpawnCondition.Underworld.Chance * 0.5f;
            }

            else
            {
                return 0f;
            }

        }
       public override void NPCLoot()  //Npc drop
        {
			if(Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessShard")); //Item spawn
			}
            if (Main.rand.Next(5) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessFragment")); //Item spawn
            }
            Item.NewItem(npc.getRect(), mod.ItemType("DarknessDrop"), 4 + Main.rand.Next(3));
        }
        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            var p = player.GetModPlayer<CavesPlayer>(mod);
            if (Main.expertMode)
            {
                if (mod.BuffType("Darkness") >= 0 && p.dreamShield == false)
                {
                    player.AddBuff(mod.BuffType("Darkness"), 240, true);
                    player.AddBuff(BuffID.Blackout, 240, true);
                }
            }
            else
            {
                if (Main.rand.Next(2) == 0)
                {
                    if (mod.BuffType("Darkness") >= 0 && p.dreamShield == false)
                    {
                        player.AddBuff(mod.BuffType("Darkness"), 240, true);
                        player.AddBuff(BuffID.Darkness, 240, true);
                    }
                }
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
