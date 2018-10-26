using HamstarHelpers.Components.Config;
using System;
using System.Collections.Generic;
using Terraria.ID;


namespace Encounters {
	public class InvaderDefinition {
		public IDictionary<string, float> InvaderDangerRatings = new Dictionary<string, float>();
		public IDictionary<string, ISet<string>> InvaderBiomes = new Dictionary<string, ISet<string>>();
		public IDictionary<string, ISet<string>> InvaderRequisiteBoss = new Dictionary<string, ISet<string>>();
	}




	public class EncountersConfigData : ConfigurationDataBase {
		public readonly static string ConfigFileName = "Encounters Config.json";



		////////////////

		public string VersionSinceUpdate = "";

		public bool DebugModeInfo = false;

		public string[] Flockables = new string[0];
		public InvaderDefinition Invaders = new InvaderDefinition();



		////////////////

		private float DangerCompute( params float[] args ) {
			float danger = 0f;
			foreach( float arg in args ) {
				danger += arg;	//( 1f - danger ) * arg;
			}
			return danger / ((float)args.Length + 1f);
		}

		public void SetDefaults() {
			this.Flockables = new string[] {
				"Any Bat",
				"Vanilla:"+NPCID.Bee
			};

			float is_normal = 0.5f;
			float is_small = 0.85f;				//0.5f;
			float is_large = 0f;                //-0.25f;
			float is_unmoving = 0f;
			float is_slow = 0f;					//-0.25f;
			float is_fast = 1f;					//0.5f;
			float is_slime = 0.25f;
			float is_high_jumper = 0.75f;
			float is_homing = 0.85f;			//0.5f;
			float is_hovering = 0.5f;			//0.5f;
			float is_nocliping = 1f;			//0.5f;
			float is_hiding = 0.75f;			//0.35f;
			float is_bat = 0.75f;				//0.5f;
			float is_worm = 0.75f;				//0.5f;
			float is_shooter_basic = 0.65f;		//0.3f;
			float is_shooter_enhanced = 0.8f;	//0.5f;
			float is_shooter_supreme = 1f;      //0.4f;
			float is_teleporting = 1f;		//0.4f;
			float is_replicating = 1f;
			float is_growing = 1f;

			this.Invaders.Clear();
			this.Invaders[ "Vanilla:"+NPCID.EyeofCthulhu ] = new Dictionary<string, float>() {
				{ "Vanilla:"+NPCID.Pinky, this.DangerCompute(is_normal, is_slime, is_small) },
				{ "Vanilla:"+NPCID.CursedSkull, this.DangerCompute(is_homing, is_nocliping, is_slow) },
				{ "Vanilla:"+NPCID.BoneSerpentHead, this.DangerCompute(is_worm, is_large) },	//?
				{ "Vanilla:"+NPCID.CorruptBunny, this.DangerCompute(is_normal, is_small) },
				{ "Vanilla:"+NPCID.Demon, this.DangerCompute(is_bat, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.Wraith, this.DangerCompute(is_hovering, is_homing, is_nocliping) },
				{ "Vanilla:"+NPCID.WyvernHead, this.DangerCompute(is_homing, is_fast, is_slow, is_nocliping, is_large) },
				{ "Vanilla:"+NPCID.Corruptor, this.DangerCompute(is_bat, is_shooter_basic) },
				{ "Vanilla:"+NPCID.LeechHead, this.DangerCompute(is_worm, is_fast) },
				{ "Vanilla:"+NPCID.ChaosElemental, this.DangerCompute(is_normal, is_teleporting, is_fast) },
				{ "Vanilla:"+NPCID.Gastropod, this.DangerCompute(is_hovering, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.RedDevil, this.DangerCompute(is_bat, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.Vampire, this.DangerCompute(is_normal, is_bat, is_fast, is_small) },
				{ "Vanilla:"+NPCID.PigronCorruption, this.DangerCompute(is_homing, is_nocliping, is_fast, is_hiding) },
				{ "Vanilla:"+NPCID.RuneWizard, this.DangerCompute(is_teleporting, is_shooter_enhanced, is_unmoving) },
				{ "Vanilla:"+NPCID.Bee, this.DangerCompute(is_small, is_fast, is_homing) },
				{ "Vanilla:"+NPCID.PirateCaptain, this.DangerCompute(is_normal, is_slow, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.IceGolem, this.DangerCompute(is_normal, is_slow, is_large, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.RainbowSlime, this.DangerCompute(is_slime, is_large) },
				{ "Vanilla:"+NPCID.RaggedCaster, this.DangerCompute(is_teleporting, is_shooter_supreme, is_unmoving) },
				{ "Vanilla:"+NPCID.Necromancer, this.DangerCompute(is_teleporting, is_teleporting, is_shooter_supreme, is_unmoving) },
				{ "Vanilla:"+NPCID.DiabolistRed, this.DangerCompute(is_teleporting, is_teleporting, is_shooter_supreme, is_unmoving) },
				{ "Vanilla:"+NPCID.DiabolistWhite, this.DangerCompute(is_teleporting, is_teleporting, is_shooter_supreme, is_unmoving) },
				{ "Vanilla:"+NPCID.BoneLee, this.DangerCompute(is_normal, is_small, is_fast, is_high_jumper) },
				{ "Vanilla:"+NPCID.GiantCursedSkull, this.DangerCompute(is_large, is_homing, is_nocliping, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.Paladin, this.DangerCompute(is_normal, is_large, is_slow, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.SkeletonSniper, this.DangerCompute(is_normal, is_slow, is_hiding, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.TacticalSkeleton, this.DangerCompute(is_normal, is_slow, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.SkeletonCommando, this.DangerCompute(is_normal, is_slow, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.Ghost, this.DangerCompute(is_hovering, is_homing, is_nocliping) },
				{ "Vanilla:"+NPCID.StardustCellBig, this.DangerCompute(is_normal, is_homing, is_replicating, is_replicating) },
				{ "Vanilla:"+NPCID.StardustCellSmall, this.DangerCompute(is_normal, is_homing, is_small) },
				{ "Vanilla:"+NPCID.StardustJellyfishBig, this.DangerCompute(is_homing, is_hovering, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.StardustSoldier, this.DangerCompute(is_normal, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.SolarDrakomireRider, this.DangerCompute(is_normal, is_large, is_fast, is_high_jumper, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.SolarSolenian, this.DangerCompute(is_normal, is_fast, is_fast, is_high_jumper) },
				{ "Vanilla:"+NPCID.SolarCorite, this.DangerCompute(is_fast, is_fast, is_homing, is_high_jumper, is_nocliping) },
				{ "Vanilla:"+NPCID.NebulaBrain, this.DangerCompute(is_homing, is_shooter_enhanced, is_teleporting) },
				{ "Vanilla:"+NPCID.NebulaBeast, this.DangerCompute(is_normal, is_fast, is_fast, is_shooter_enhanced) },
				//{ "Vanilla:"+NPCID.NebulaHeadcrab, this.DangerCompute(is_fast, is_homing) },
				{ "Vanilla:"+NPCID.NebulaSoldier, this.DangerCompute(is_normal, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.VortexRifleman, this.DangerCompute(is_normal, is_fast, is_homing, is_shooter_enhanced) },
				{ "Vanilla:"+NPCID.VortexHornetQueen, this.DangerCompute(is_normal, is_slow, is_shooter_supreme, is_replicating, is_replicating) },
				{ "Vanilla:"+NPCID.VortexLarva, this.DangerCompute(is_normal, is_slow, is_small, is_growing, is_growing) },
				{ "Vanilla:"+NPCID.VortexHornet, this.DangerCompute(is_normal, is_homing, is_fast, is_growing) },
				{ "Vanilla:"+NPCID.Medusa, this.DangerCompute(is_normal, is_shooter_supreme) },
				{ "Vanilla:"+NPCID.DesertDjinn, this.DangerCompute(is_teleporting, is_slow, is_shooter_supreme, is_unmoving) },
				{ "Vanilla:"+NPCID.Lavabat, this.DangerCompute(is_bat) },
				{ "Vanilla:"+NPCID.GiantFlyingFox, this.DangerCompute(is_bat) },
				{ "Vanilla:"+NPCID.FlyingSnake, this.DangerCompute(is_bat, is_homing) }
			};
		}


		////////////////

		public bool UpdateToLatestVersion() {
			var new_config = new EncountersConfigData();
			var vers_since = this.VersionSinceUpdate != "" ?
				new Version( this.VersionSinceUpdate ) :
				new Version();

			if( vers_since >= EncountersMod.Instance.Version ) {
				return false;
			}

			this.VersionSinceUpdate = EncountersMod.Instance.Version.ToString();

			return true;
		}
	}
}
