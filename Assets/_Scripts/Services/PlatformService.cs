using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CursorState
{
	Default,
	Hidden,
}

public class PlatformService : MonoBehaviour
{
	// public bool IsLandscape
	// 	=> true; // for now
	// public CursorState PreferredCursor
	// 	{ get; set; }
	
	public bool IsMobile
		=> false; // for now
	
	public bool IsFullscreen
		=> Screen.fullScreen;
	
	public void TryToggleFullscreen()
	{
		Screen.fullScreen = !IsFullscreen;
	}

	private void Awake()
	{
		Locator.Platform = this;

		// move this Mono to an additive "Systems" scene
		DontDestroyOnLoad(gameObject);
	}
}
