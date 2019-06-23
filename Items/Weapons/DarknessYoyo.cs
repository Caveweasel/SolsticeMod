using SolsticeMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items.Weapons
{
	public class DarknessYoyo : ModItem
	{
		public override void SetStaticDefaults()
		{
			//Tooltip.SetDefault("Shoots out an example yoyo");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 32;
			item.height = 26;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 13;
			item.rare = 1;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = 5000;
			item.shoot = mod.ProjectileType<DarknessPYoyo>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarknessDrop", 6);
			recipe.AddIngredient(null, "DarknessShard", 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
