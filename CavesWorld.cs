using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace SolsticeMod
{
    public class CavesWorld : ModWorld
    {
		public static bool downedDarkMon = false;
		
		public override void Initialize()
		{
			downedDarkMon = false;
		}
		
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedDarkMon) downed.Add("darknessMonster");

			return new TagCompound {
				{"downed", downed}
			};
		}
		
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedDarkMon = downed.Contains("darknessMonster");
		}
		
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedDarkMon = flags[0];
			}
			else
			{
				ErrorLogger.Log("CavesMod: Unknown loadVersion: " + loadVersion);
			}
		}
		
		public override void NetSend(BinaryWriter writer)
		{
			BitsByte flags = new BitsByte();
			flags[0] = downedDarkMon;
			writer.Write(flags);
		}
		
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedDarkMon = flags[0];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}
    }
}