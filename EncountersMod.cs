using HamstarHelpers.Components.Config;
using HamstarHelpers.Helpers.DebugHelpers;
using System;
using Terraria.ModLoader;


namespace Encounters {
	partial class EncountersMod : Mod {
		public static EncountersMod Instance { get; private set; }



		////////////////

		public JsonConfig<EncountersConfigData> ConfigJson { get; private set; }
		public EncountersConfigData Config { get { return this.ConfigJson.Data; } }


		////////////////

		public EncountersMod() {
			this.ConfigJson = new JsonConfig<EncountersConfigData>(
				EncountersConfigData.ConfigFileName, ConfigurationDataBase.RelativePath, new EncountersConfigData() );
		}

		////////////////

		public override void Load() {
			EncountersMod.Instance = this;

			this.LoadConfig();
		}

		private void LoadConfig() {
			if( !this.ConfigJson.LoadFile() ) {
				this.ConfigJson.SaveFile();
			}

			if( this.Config.UpdateToLatestVersion() ) {
				LogHelpers.Log( "Encounters updated to " + EncountersConfigData.ConfigVersion.ToString() );
				this.ConfigJson.SaveFile();
			}
		}

		public override void Unload() {
			EncountersMod.Instance = null;
		}


		////////////////

		public override object Call( params object[] args ) {
			if( args.Length == 0 ) { throw new Exception( "Undefined call type." ); }

			string call_type = args[0] as string;
			if( args == null ) { throw new Exception( "Invalid call type." ); }

			var new_args = new object[args.Length - 1];
			Array.Copy( args, 1, new_args, 0, args.Length - 1 );

			return EncountersAPI.Call( call_type, new_args );
		}
	}
}
