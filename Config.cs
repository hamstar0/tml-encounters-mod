using HamstarHelpers.Components.Config;
using System;


namespace Encounters {
	public class EncountersConfigData : ConfigurationDataBase {
		public readonly static Version ConfigVersion = new Version( 1, 0, 0 );
		public readonly static string ConfigFileName = "Encounters Config.json";


		////////////////

		public string VersionSinceUpdate = "";

		public bool DebugModeInfo = false;



		////////////////

		public bool UpdateToLatestVersion() {
			var new_config = new EncountersConfigData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= EncountersConfigData.ConfigVersion ) {
				return false;
			}

			this.VersionSinceUpdate = EncountersConfigData.ConfigVersion.ToString();

			return true;
		}
	}
}
