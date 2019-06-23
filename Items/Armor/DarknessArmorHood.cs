using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarknessArmorHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You feel a dark aura around it.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 9;
			item.defense = 5;
            item.expert = true;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("DarknessArmorBreastplate") && legs.type == mod.ItemType("DarknessArmorLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% increased movement speed and damage";
            player.meleeDamage += 0.1f;
            player.thrownDamage += 0.1f;
            player.rangedDamage += 0.1f;
            player.magicDamage += 0.1f;
            player.minionDamage += 0.1f;
            player.moveSpeed += 0.1f;
            //player.AddBuff(BuffID.Cursed, 2);
            //player.AddBuff(BuffID.Darkness, 2);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarknessDrop", 10);
            recipe.AddIngredient(null, "DarknessShard", 5);
            recipe.AddIngredient(null, "DarknessCoreFragment");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}