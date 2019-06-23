using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items
{
	public class DarknessIncense : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darkness Incense");
            Tooltip.SetDefault("Highly increases dark enemy spawn rate, and certain enemies can spawn"
                + "\nDamage decreased by 10%"
                + "\nBest results at night"
                + "\n10 minute duration");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 14;
            item.maxStack = 30;
            item.value = 0;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return CavesWorld.downedDarkMon == true; //can use only at night //you can't spawn this boss multiple times
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<CavesPlayer>(mod);
            player.AddBuff(mod.BuffType("DarkIncense"), 36060, true);

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarknessDrop", 2);
            recipe.AddIngredient(null, "DarknessShard", 2);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}