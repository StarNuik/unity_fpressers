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

	private AppState state => Locator.State;

	private void OnEnable()
	{
		button.onClick.AddListener(ToggleFullscreen);
	}

	private void Update()
	{
		text.enabled = !WebPlatform.IsMobile && WebPlatform.IsFullscreen;

		var sprite = WebPlatform.IsFullscreen ? disableSprite : enableSrite;
		buttonImage.sprite = sprite;
	}

	private void ToggleFullscreen()
	{
		Debug.Log("[ ToggleFullscreen ]");
	}
}
