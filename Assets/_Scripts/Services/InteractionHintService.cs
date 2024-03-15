using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class InteractionHintService : MonoBehaviour
{
	[Multiline]
	[Editor] string text;

	private AppState state => Locator.State;
	private EndingRouteService route => Locator.RouteTracker;
	private TextDisplayService textDisplay => Locator.TextDisplay;

	private bool isActive
		=> state.IsInteractionHovered
		&& !state.IsPlayingCutscene
		&& !state.SuppressPlayer // just in case
		&& !route.HasInteractedOnce;

	private bool wasShown;

	private void Update()
	{
		var payload = isActive ? text : null;
		textDisplay.InteractionHintChannel = payload;
	}
}
