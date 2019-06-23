using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DarknessArmorLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Darkness Leggings");
            Tooltip.SetDefault("\n5% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarknessDrop", 15);
            recipe.AddIngredient(null, "DarknessShard", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}