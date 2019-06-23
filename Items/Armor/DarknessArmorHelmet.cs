using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarknessArmorHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Darkness Helmet");
            //Tooltip.SetDefault("This is a modded helmet.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DarknessArmorBreastplate") && legs.type == mod.ItemType("DarknessArmorLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "10% icreased movement speed";
            //player.meleeDamage *= 0.05f;
            //player.thrownDamage *= 0.05f;
            //player.rangedDamage *= 0.05f;
            //player.magicDamage *= 0.05f;
            //player.minionDamage *= 0.05f;

            player.moveSpeed += 0.1f;
        }

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarknessDrop", 10);
            recipe.AddIngredient(null, "DarknessShard", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}