using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Projectiles
{
    public class LightArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light Arrow");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;  //Can the projectile deal damage to enemies?
            projectile.hostile = false;  //Can the projectile deal damage to the player?
            projectile.ranged = true;
            projectile.penetrate = 10;
            projectile.timeLeft = 600;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            aiType = ProjectileID.WoodenArrowFriendly;
        }

        /*       public override void AI()
               {
                   if (projectile.owner == Main.myPlayer && Main.rand.Next(4) == 0)
                   {
                       Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 14, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
                   }
               }*/
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("HolyFlames"), 300, false);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1, 1f, 0f);
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 0, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f);
            }
        }
    }
}