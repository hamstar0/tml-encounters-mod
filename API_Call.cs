using System;


namespace Encounters {
	public static partial class EncountersAPI {
		internal static object Call( string call_type, params object[] args ) {
			switch( call_type ) {
			case "GetModSettings":
				return EncountersAPI.GetModSettings();
			default:
				throw new Exception( "No such api call " + call_type );
			}
		}
	}
}
