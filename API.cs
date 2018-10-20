namespace Encounters {
	public static partial class EncountersAPI {
		public static EncountersConfigData GetModSettings() {
			return EncountersMod.Instance.Config;
		}
	}
}
