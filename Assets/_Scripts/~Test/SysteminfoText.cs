using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class SysteminfoText : MonoBehaviour
{
	[Editor] TMP_Text text;

	private void Update()
	{
		WebPlatform.NotifyLoaded();
		text.text = $"SystemInfo.operatingSystem: {SystemInfo.operatingSystem}\nSystemInfo.operatingSystemFamily: {SystemInfo.operatingSystemFamily}\nSystemInfo.deviceModel: {SystemInfo.deviceModel}\nSystemInfo.deviceType: {SystemInfo.deviceType}\nDevice.SystemInfo.deviceType: {UnityEngine.Device.SystemInfo.deviceType}";
	}
}
