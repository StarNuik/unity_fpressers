using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;

public class FullscreenOverlayService : MonoBehaviour
{
	[Editor] Image buttonImage;
	[Editor] TMP_Text text;
	[Editor] Sprite enableSrite;
	[Editor] Sprite disableSprite;

	private void Update()
	{
		text.enabled = !Platform.IsHandheld && Platform.IsFullscreen;

		var sprite = Platform.IsFullscreen ? disableSprite : enableSrite;
		buttonImage.sprite = sprite;
	}

	// private void ToggleFullscreen()
	// {
	// 	platform.TryToggleFullscreen();
	// }
}
