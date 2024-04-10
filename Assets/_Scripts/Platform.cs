using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SystemInfo = UnityEngine.Device.SystemInfo;
using Screen = UnityEngine.Device.Screen;

public static class Platform
{
	public static bool IsHandheld
		=> SystemInfo.deviceType == DeviceType.Handheld;
	
	public static bool IsFullscreen
		=> Screen.fullScreen;
	
	public static T SwitchIfHandheld<T>(T handheld, T otherwise)
		=> IsHandheld
			? handheld
			: otherwise;
}
