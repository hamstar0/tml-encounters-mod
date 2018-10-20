using HamstarHelpers.Components.Config;
using HamstarHelpers.Helpers.DebugHelpers;
using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;


namespace Encounters {
	partial class EncountersMod : Mod {
		public static string GithubUserName { get { return "hamstar0"; } }
		public static string GithubProjectName { get { return "tml-encounters-mod"; } }

		public static string ConfigFileRelativePath {
			get { return ConfigurationDataBase.RelativePath + Path.DirectorySeparatorChar + EncountersConfigData.ConfigFileName; }
		}
		public static void ReloadConfigFromFile() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reload configs outside of single player." );
			}
			if( EncountersMod.Instance != null ) {
				if( !EncountersMod.Instance.ConfigJson.LoadFile() ) {
					EncountersMod.Instance.ConfigJson.SaveFile();
				}
			}
		}

		public static void ResetConfigFromDefaults() {
			if( Main.netMode != 0 ) {
				throw new Exception( "Cannot reset to default configs outside of single player." );
			}

			var new_config = new EncountersConfigData();
			//new_config.SetDefaults();

			EncountersMod.Instance.ConfigJson.SetData( new_config );
			EncountersMod.Instance.ConfigJson.SaveFile();
		}
	}
}
