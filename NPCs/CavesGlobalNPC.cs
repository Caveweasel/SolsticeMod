using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.NPCs
{
    public class CavesGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool darkness = false;
        public bool holyFlames = false;

        public override void ResetEffects(NPC npc)
        {
            darkness = false;
            holyFlames = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (darkness)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 3;
                if (damage < 2)
                {
                    damage = 2;
                }
            }

            if (holyFlames)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 5;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            {
                if (darkness)
                {
                    if (Main.rand.Next(4) < 3)
                    {
                        int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 272, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 0;
                        Main.dust[dust].velocity.Y -= 0;
                       /* if (Main.rand.Next(4) == 0)
                        {
                            Main.dust[dust].noGravity = false;
                            Main.dust[dust].scale *= 0.5f;
                        }*/
                    }
                    Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
                }

                if (holyFlames)
                {
                    if (Main.rand.Next(4) < 3)
                    {
                        int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 133, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1f);
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].velocity *= 0;
                        Main.dust[dust].velocity.Y -= 0;
                        /* if (Main.rand.Next(4) == 0)
                         {
                             Main.dust[dust].noGravity = false;
                             Main.dust[dust].scale *= 0.5f;
                         }*/
                    }
                    Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
                }
            }
        }
    }
}