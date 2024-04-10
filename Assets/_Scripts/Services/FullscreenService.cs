using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class FullscreenService : MonoBehaviour
{
	public void TryToggle()
	{
		Screen.fullScreen = !Platform.IsFullscreen;
	}

	private void Awake()
	{
		Locator.Fullscreen = this;

		// move this Mono to an additive "Systems" scene
		// DontDestroyOnLoad(gameObject);
	}
}
