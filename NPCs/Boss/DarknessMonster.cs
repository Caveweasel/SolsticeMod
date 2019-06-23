using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs.Boss
{
	[AutoloadBossHead]
    public class DarknessMonster : ModNPC
    {
		public bool downed;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darkness Monster");			
            Main.npcFrameCount[npc.type] = 3;
		}
        public override void SetDefaults()
        {
            //npc.name = "DarknessMonster";
            //npc.displayName = "Darkness Monster";
            npc.aiStyle = 2;  //5 is the flying AI
            npc.lifeMax = 1600;   //boss life
            npc.damage = 12;  //boss damage
            npc.defense = 6;    //boss defense
            npc.knockBackResist = 0f;
            npc.width = 152;
            npc.height = 110;
            animationType = NPCID.DemonEye;   //this boss will behave like the DemonEye
			aiType = NPCID.DemonEye;
            Main.npcFrameCount[npc.type] = 2;    //boss frame/animation 
            npc.value = 10000; //Item.buyPrice(0, 2, 0, 0);
            npc.npcSlots = 1f;
            npc.boss = true;  
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[31] = true;
            npc.buffImmune[mod.BuffType("Darkness")] = true;
            music = MusicID.Boss1;
            npc.netAlways = true;
			bossBag = mod.ItemType("DarkMonTreasureBag"); // Needed for the NPC to drop loot bag.
			downed = false;
        }
        //public override void AutoloadHead(ref string headTexture, ref string bossHeadTexture)
        //{
            //bossHeadTexture = "CavesMod/NPCs/Boss/DarkMonster_Head_Boss"; //the boss head texture
        //}
		/* public override void NPCLoot()
		{
		if (Main.expertMode) //if it's expert mode the treasure bag will drop
            {
                npc.DropBossBags();
            }
		} */
        public override void BossLoot(ref string name, ref int potionType)
        {
            /*if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkMonTrophy"));
            }*/
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkMonMask"));
            }
            if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				potionType = ItemID.LesserHealingPotion;   //boss drops
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarknessDrop"), 30 + Main.rand.Next(11));
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarknessShard"), 10 + Main.rand.Next(6));
			}
			CavesWorld.downedDarkMon = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);  //boss life scale in expertmode
            npc.damage = (int)(npc.damage * 0.6f);  //boss damage increase in expermode			
            npc.defense = (int)(npc.defense + numPlayers);
        }

        public override void OnHitPlayer(Player player, int dmgDealt, bool crit)
        {
            int debuff1 = mod.BuffType("Darkness");
            int debuff2 = BuffID.Blackout;
            int debuff3 = BuffID.Darkness;
            var p = player.GetModPlayer<CavesPlayer>(mod);
            if (!Main.expertMode)
            {
                if (Main.rand.Next(3) == 0)
                {
                    if (debuff1 >= 0 && debuff3 >= 0 && p.dreamShield == false)
                    {
                        player.AddBuff(debuff1, GetDebuffTime(), true);
                        player.AddBuff(debuff3, GetDebuffTime(), true);
                    }
                }
            }
            else
            {
                if (Main.rand.Next(2) == 0)
                {
                    if (debuff1 >= 0 && debuff2 >= 0 && p.dreamShield == false)
                    {
                        player.AddBuff(debuff1, GetDebuffTime(), true);
                        player.AddBuff(debuff2, GetDebuffTime(), true);
                    }
                }
            }
        }
        public int GetDebuffTime()
        {
            int time;
            switch (Main.rand.Next(3))
            {
                case 0:
                    time = 180;
                    break;
                case 1:
                    time = 240;
                    break;
                case 2:
                    time = 300;
                    break;
                default:
                    return -1;
            }
            return time;
        }
        //		public override void AI()
        //		{
        //			npc.AI();
        //		}
    }
}