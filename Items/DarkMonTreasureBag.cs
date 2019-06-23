using System;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace SolsticeMod.Items
{
	public class DarkMonTreasureBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 32;
			item.height = 32;
			item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("DarknessMonster");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
            //player.TryGettingDevArmor();
            //if (Main.rand.Next(7) == 0)
            player.QuickSpawnItem(mod.ItemType("DarknessShard"), 10 + Main.rand.Next(6));
            player.QuickSpawnItem(mod.ItemType("DarknessDrop"), 30 + Main.rand.Next(11));
            player.QuickSpawnItem(mod.ItemType("DreamShield"));
            //player.QuickSpawnItem(mod.ItemType("ElementResidue"));
            //player.QuickSpawnItem(mod.ItemType("PurityTotem"));
            //player.QuickSpawnItem(mod.ItemType("SixColorShield"));
        }
	}
}
 

