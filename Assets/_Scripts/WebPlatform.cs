#if !UNITY_EDITOR && UNITY_WEBGL
#define WEBGL_BUILD
#endif

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public static class WebPlatform
{
	[DllImport("__Internal")]
	private static extern void WebSendLoadProgress(float progress);
	
	[DllImport("__Internal")]
	private static extern void WebNotifyLoaded();

	[DllImport("__Internal")]
	private static extern double WebGetStartupDelay();

	public static void SendLoadProgress(float value)
	{
		var remapped = Mathf.Clamp01(value) + 1f;
		
		#if WEBGL_BUILD
		WebSendLoadProgress(remapped);
		#endif

		// Debug.Log($"[ WebPlatform.SendLoadProgress ] {remapped}");
	}

	public static void NotifyLoaded()
	{
		// Debug.Log("[ WebPlatform.NotifyLoaded ]");
		
		#if WEBGL_BUILD
		WebNotifyLoaded();
		#endif
	}

	public static float GetStartupDelay()
	{
		return 
		#if WEBGL_BUILD
			(float)WebGetStartupDelay()
		#else
			0f
		#endif
		;
	}
}
