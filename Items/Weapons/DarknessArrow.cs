using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items.Weapons
{
	public class DarknessArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Darkness Arrow");
            //Tooltip.SetDefault("This is a modded bullet ammo.");
		}

		public override void SetDefaults()
		{
			item.damage = 9;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 25;
			item.rare = 1;
			item.shoot = mod.ProjectileType("DarknessArrowP");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 2f;                  //The speed of the projectile
			item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
/*		public override void OnConsumeAmmo(Player player)
		{
			if (Main.rand.NextBool(5))
			{
				player.AddBuff(BuffID.Wrath, 300);
			}
		}*/

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 50);
            recipe.AddIngredient(null, "DarknessDrop", 1);
            recipe.AddIngredient(null, "DarknessShard", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
