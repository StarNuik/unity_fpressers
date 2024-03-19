using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class MovementHintService : MonoBehaviour
{
	[Editor] TextAsset text;
	[Editor] float dismissalDistance;

	private AppState state => Locator.State;
	private TextDisplayService textDisplay => Locator.TextDisplay;
	private TranslationService translation => Locator.Translation;

	private float travelDist => state.DistanceTraveled;
	private bool isActive
		=> !state.IsPlayingCutscene
		&& !state.SuppressPlayer // just in case
		&& travelDist <= dismissalDistance;

	private void Update()
	{
		var translated = translation.ToString(text);
		var payload = isActive ? translated : null;
		textDisplay.MovementHintChannel = payload;
	}
}
