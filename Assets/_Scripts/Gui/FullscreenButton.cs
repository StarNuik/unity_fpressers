using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// WebGl fullscreen requires hacks
public class FullscreenButton : MonoBehaviour, IPointerDownHandler
{
	private FullscreenService fullscreen => Locator.Fullscreen;

	public void OnPointerDown(PointerEventData _)
	{
		fullscreen.TryToggle();
	}
}
