using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemInfo = UnityEngine.Device.SystemInfo;

public class CursorServiceFactory : MonoBehaviour
{
	private void Awake()
	{
		var t = Platform.SwitchIfHandheld(
			typeof(NoopCursorService),
			typeof(DesktopCursorService)
		);
		gameObject.AddComponent(t);
	}
}
