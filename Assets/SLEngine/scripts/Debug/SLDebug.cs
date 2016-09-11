using UnityEngine;
using System.Collections;
using System;

namespace SLEngine.Debug
{
	public class SLDebug{

	#if UNITY_EDITOR
		static public Action< object > Log = UnityEngine.Debug.Log;
		static public Action< object > LogWarning = UnityEngine.Debug.LogWarning;
		static public Action< object > LogError = UnityEngine.Debug.LogError;
	#else
		public static void Log(string p_log)
		{
			#if DEBUG
			UnityEngine.Debug.Log (p_log);
			#endif
		}

		public static void LogWarning(string p_log)
		{
			#if DEBUG
			UnityEngine.Debug.LogWarning (p_log);
			#endif
		}

		public static void LogError(string p_log)
		{
			#if DEBUG
			UnityEngine.Debug.LogError (p_log);
			#endif
		}

	#endif 
	}
}
