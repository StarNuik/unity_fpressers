using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorServiceFactory : MonoBehaviour
{
	private void Start()
	{
		Debug.Log($"{SystemInfo.deviceType}");
		var t = Platform.SwitchIfHandheld(
			typeof(NoopCursorService),
			typeof(DesktopCursorService)
		);
		gameObject.AddComponent(t);
	}
}
