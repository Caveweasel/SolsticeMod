using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod
{
    // ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
    // several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
    public class CavesPlayer : ModPlayer
    {
        public bool darkness;
        public bool holyFlames;
        public bool darkIncense;
        public bool dreamShield = false;

        public override void ResetEffects()
        {
            darkness = false;
            dreamShield = false;
            darkIncense = false;
        }

        public override void clientClone(ModPlayer clientClone)
        {
            CavesPlayer clone = clientClone as CavesPlayer;
            // Here we would make a backup clone of values that are only correct on the local players Player instance.
            // Some examples would be RPG stats from a GUI, Hotkey states, and Extra Item Slots
            // clone.someLocalVariable = someLocalVariable;
        }

        public override void UpdateDead()
        {
            darkness = false;
            holyFlames = false;
            darkIncense = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (darkness)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 3;
            }

            if (holyFlames)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 5;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (darkness)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 272, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0;
                    Main.dust[dust].velocity.Y -= 0;
                    /* if (Main.rand.Next(4) == 0)
                     {
                         Main.dust[dust].noGravity = false;
                         Main.dust[dust].scale *= 0.5f;
                     }*/
                }
                Lighting.AddLight(player.position, 0.1f, 0.2f, 0.7f);
            }

            if (holyFlames)
            {
                if (Main.rand.Next(4) < 3)
                {
                    int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 133, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0;
                    Main.dust[dust].velocity.Y -= 0;
                    /* if (Main.rand.Next(4) == 0)
                     {
                         Main.dust[dust].noGravity = false;
                         Main.dust[dust].scale *= 0.5f;
                     }*/
                }
                Lighting.AddLight(player.position, 0.1f, 0.2f, 0.7f);
            }
        }

        public override float UseTimeMultiplier(Item item)
        {
            return dreamShield ? 1.5f : 1f;
        }
    }
}