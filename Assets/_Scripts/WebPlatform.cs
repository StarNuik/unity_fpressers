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

	// [DllImport("__Internal")]
	// private static extern bool WebIsMobile();

	// [DllImport("__Internal")]
	// private static extern bool WebIsLandscape();

	// public static bool IsMobile
	// {
	// 	get
	// 	{
	// 		#if WEBGL_BUILD
	// 		return WebIsMobile();
	// 		#endif

	// 		return false;
	// 	}
	// }

	// public static bool IsLandscape
	// {
	// 	get
	// 	{
	// 		#if WEBGL_BUILD
	// 		return WebIsLandscape();
	// 		#endif

	// 		return true;
	// 	}
	// }

	public static bool IsMobile
		=> SystemInfo.deviceType == DeviceType.Handheld;
	
	public static bool IsLandscape
		=> Screen.orientation != ScreenOrientation.Portrait
		&& Screen.orientation != ScreenOrientation.PortraitUpsideDown;
	
	public static bool IsFullscreen
		=> Screen.fullScreen;

	public static void SetFullscreen(bool isFullscreen)
	{
		throw new NotImplementedException();
	}
}
