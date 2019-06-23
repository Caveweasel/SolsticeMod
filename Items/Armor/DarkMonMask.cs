using Terraria.ModLoader;

namespace SolsticeMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DarkMonMask : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 22;
			item.rare = 1;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}