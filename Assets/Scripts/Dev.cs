using UnityEngine;

public class Dev {

	public static void Log (object log) {
		if (Debug.isDebugBuild) {
			Debug.Log(log);
		}
	}

	public static void ApiLog (string log) {
		if (Debug.isDebugBuild) {
			Debug.Log("<color=blue>"+log+"</color>");
		}
	}

	public static void ApiErrorLog (string log) {
		if (Debug.isDebugBuild) {
			Debug.Log("<color=red>"+log+"</color>");
		}
	}

	public static void JsonLog (object obj) {
		if (Debug.isDebugBuild) {
			var log = JsonUtility.ToJson(obj);
			Debug.Log(log);
		}
	}

}
