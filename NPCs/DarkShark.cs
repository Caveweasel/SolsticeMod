using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/blushiemagic/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class DarkShark : ModNPC
	{

        int frameCounter;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Shark");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.WanderingEye];
		}

		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 46;
			npc.damage = 40;
			npc.defense = 6;
			npc.lifeMax = 800;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            npc.buffImmune[31] = true;
            npc.lavaImmune = true;
            npc.value = 100f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 2;
			aiType = NPCID.WanderingEye;
			animationType = NPCID.WanderingEye;
            frameCounter = 0;
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            var p = spawnInfo.player.GetModPlayer<CavesPlayer>(mod);

            if (CavesWorld.downedDarkMon == true && p.darkIncense == true)
            {
                return SpawnCondition.Overworld.Chance * 0.1f;
            }

            else
			{
				return 0f;
			}

            //this.npc.altTexture

        }
       public override void NPCLoot()  //Npc drop
        {
			//if(Main.rand.Next(1,3)==1)
            //{
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessDrop"), 10 + Main.rand.Next(11));
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessShard"), 5 + Main.rand.Next(6));
                Item.NewItem(npc.getRect(), mod.ItemType("DarknessFragment"), 5 + Main.rand.Next(6));
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

            if (Main.rand.Next(2) == 0)
            {
                if (mod.BuffType("Darkness") >= 0 && p.dreamShield == false)
                {
                    player.AddBuff(mod.BuffType("Darkness"), 240, true);
                }
                
            }
        }
        public override void AI()
        {

            base.AI();

            if (Main.expertMode)
            {
                if (npc.life <= 800)
                {
                    npc.noTileCollide = true;

                }
            }
            else
            {
                if (npc.life <= 400)
                {
                    npc.noTileCollide = true;

                }
            }

            frameCounter++;

            if (Main.expertMode && npc.life <= 800)
            {
                if (frameCounter >= 600)
                {
                    var t = mod.NPCType("DarkSpikeBig");
                    var tile = npc.Center.ToTileCoordinates();
                    NPCLoader.GetNPC(t).SpawnNPC(tile.X, tile.Y);
                    //npc.NewNPC(  //(int X, int Y, int Type, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255);

                    frameCounter = 0;
                }
            }

            else
            {
                if (npc.life <= 400)
                {
                    if (frameCounter >= 900)
                    {
                        var t = mod.NPCType("DarkSpikeBig");
                        var tile = npc.Center.ToTileCoordinates();
                        NPCLoader.GetNPC(t).SpawnNPC(tile.X, tile.Y);
                        //npc.NewNPC(  //(int X, int Y, int Type, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255);

                        frameCounter = 0;
                    }
                }
            }
        }
    }
}
