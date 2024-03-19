using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class InteractionHintService : MonoBehaviour
{
	[Editor] TextAsset text;

	private AppState state => Locator.State;
	private EndingRouteService route => Locator.RouteTracker;
	private TextDisplayService textDisplay => Locator.TextDisplay;
	private TranslationService translation => Locator.Translation;

	private bool isActive
		=> state.IsInteractionHovered
		&& !state.IsPlayingCutscene
		&& !state.SuppressPlayer // just in case
		&& !route.HasInteractedOnce;

	private bool wasShown;

	private void Update()
	{
		var translated = translation.ToString(text);
		var payload = isActive ? translated : null;
		textDisplay.InteractionHintChannel = payload;
	}
}
