using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolsticeMod.Items
{
    public class DarkLookEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Looking Eye");
            Tooltip.SetDefault("Summons the Darkness Monster");
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
            return !NPC.AnyNPCs(mod.NPCType("DarknessMonster")) && !Main.dayTime; //can use only at night //you can't spawn this boss multiple times
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("DarknessMonster"));   //boss spawn
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);

            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DarknessDrop", 3);
            recipe.AddIngredient(ItemID.Lens, 1);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
