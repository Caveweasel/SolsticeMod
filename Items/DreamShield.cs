using Terraria;
using Terraria.ModLoader;

namespace SolsticeMod.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class DreamShield : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("Shield of Dreams");
            Tooltip.SetDefault("The shield of light."
				+ "\nGrants immunity to the Darkness Flames debuff.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 9;
			item.accessory = true;
            item.defense = 2;
            //item.lifeRegen = 1;
            item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<CavesPlayer>(mod).darkness = false;
            player.GetModPlayer<CavesPlayer>(mod).dreamShield = true;

            /*			if (player.name == "bluemagic123")
                        {
                            player.meleeDamage += 19f;
                            player.thrownDamage += 19f;
                            player.rangedDamage += 19f;
                            player.magicDamage += 19f;
                            player.minionDamage += 19f;
                            player.endurance = 1f - 0.1f * (1f - player.endurance);
                            player.GetModPlayer<ExamplePlayer>(mod).exampleShield = true;
                        }
                        else
                        {
                            player.statDefense = 0;
                            player.meleeDamage = 0.1f;
                            player.thrownDamage = 0.1f;
                            player.rangedDamage = 0.1f;
                            player.magicDamage = 0.1f;
                            player.minionDamage = 0.1f;
                            player.lifeRegen = -120;
                        }*/
        }

/*		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EquipMaterial", 60);
			recipe.AddTile(null, "ExampleWorkbench");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}