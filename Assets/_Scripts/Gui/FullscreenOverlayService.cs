using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;

public class FullscreenOverlayService : MonoBehaviour
{
	[Editor] Image buttonImage;
	[Editor] Button button;
	[Editor] TMP_Text text;
	[Editor] Sprite enableSrite;
	[Editor] Sprite disableSprite;

	private FullscreenService platform => Locator.Fullscreen;

	private void Update()
	{
		text.enabled = !platform.IsMobile && platform.IsFullscreen;

		var sprite = platform.IsFullscreen ? disableSprite : enableSrite;
		buttonImage.sprite = sprite;
	}

	// private void ToggleFullscreen()
	// {
	// 	platform.TryToggleFullscreen();
	// }
}
