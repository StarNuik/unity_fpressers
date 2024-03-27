using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

// at this point, its faster to duplicate code than to write abstractions
// #bad_practice_is_a_tool
public class MouseHintService : MonoBehaviour
{
	[Editor] TextAsset text;
	[Min(0f)]
	[Editor] float showDelay = 1f;
	[Min(1f)]
	[Editor] float dismissalPixels = 100f;

	private AppState state => Locator.State;
	private TranslationService translation => Locator.Translation;
	private TextDisplayService textDisplay => Locator.TextDisplay;

	private float pixelsTraveled => state.CameraPixelsTraveled;
	private bool isActive
		=> !state.IsPlayingCutscene
		&& !state.SuppressPlayer
		&& pixelsTraveled <= dismissalPixels;

	private void Update()
	{
		var translated = translation.ToString(text);
		var payload = isActive ? translated : null;
		textDisplay.PointerHintChannel = payload;
	}
}
