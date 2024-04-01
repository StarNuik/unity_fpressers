using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenService : MonoBehaviour
{
	public bool IsMobile
		=> false; // for now
	
	public bool IsFullscreen
		=> Screen.fullScreen;
	
	public void TryToggle()
	{
		Screen.fullScreen = !IsFullscreen;
	}

	private void Awake()
	{
		Locator.Fullscreen = this;

		// move this Mono to an additive "Systems" scene
		// DontDestroyOnLoad(gameObject);
	}
}
