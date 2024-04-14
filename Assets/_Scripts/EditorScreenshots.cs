using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EditorScreenshots : MonoBehaviour
{
	private void Awake()
	{
		#if !UNITY_EDITOR
			Destroy(this);
		#endif
	}

	private void Update()
	{
		#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			var path = Application.persistentDataPath + "/" + ChooseFilename() + ".png";
			ScreenCapture.CaptureScreenshot(path);
			Debug.Log($"Screenshot saved to: {path}");
		}
		#endif
	}

	private string ChooseFilename()
	{
		var now = DateTime.Now.ToString("yyyyMMddHHmmssffff");
		return $"fpressers_{now}";
	}
}
