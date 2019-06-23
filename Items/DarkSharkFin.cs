using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items
{
    public class DarkSharkFin : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darkness Shark Fin");
            Tooltip.SetDefault("Summons the Darkness Shark"
            + "\nPreferably use at high elevations, so the miniboss doesn't get stuck underground"
            + "\nNOTE: Darkness Shark is a miniboss and can also appear with the Darkness Incense buff");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = 0;
            item.rare = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime; //can use only at night
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("DarkShark"));   //boss spawn
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarknessDrop", 3);
            recipe.AddIngredient(null, "DarknessShard", 3);
            recipe.AddIngredient(ItemID.SharkFin);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
