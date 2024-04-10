#if !UNITY_EDITOR && UNITY_WEBGL
#define WEBGL_BUILD
#endif

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopCursorService : MonoBehaviour, ICursorService
{
	private AppState state => Locator.State;

	private bool isHidden
	{
		get => Cursor.lockState == CursorLockMode.Locked;
		set
		{
			Cursor.lockState = value
				? CursorLockMode.Locked
				: CursorLockMode.None;
		}
	}

	private bool _preferHidden;
	public bool PreferHidden
	{
		get => _preferHidden;
		set
		{
			_preferHidden = value;
			isHidden = value;
		}
	}

	private void Awake()
	{
		Locator.Cursor = this;
		
		#if WEBGL_BUILD
			// lets the browser unlock the cursor
			WebGLInput.stickyCursorLock = false;
		#endif

		state.FallthroughPressed += HideCursor;
	}

	private void Update()
	{
		// Cursor.visible = !isHidden;
	}

	private void HideCursor()
	{
		if (PreferHidden)
		{
			isHidden = true;
		}
	}
}
