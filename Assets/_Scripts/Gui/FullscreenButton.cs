using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// WebGl fullscreen requires hacks
public class FullscreenButton : MonoBehaviour, IPointerDownHandler
{
	private FullscreenService platform => Locator.Fullscreen;

	public void OnPointerDown(PointerEventData _)
	{
		platform.TryToggle();
	}
}
