using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class MovementHintService : MonoBehaviour
{
	[Multiline]
	[Editor] string text;
	[Editor] float dismissalDistance;

	private AppState state => Locator.State;
	private TextDisplayService textDisplay => Locator.TextDisplay;

	private float travelDist => state.DistanceTraveled;
	private bool isActive
		=> !state.IsPlayingCutscene
		&& !state.SuppressPlayer // just in case
		&& travelDist <= dismissalDistance;

	private void Update()
	{
		var payload = isActive ? text : null;
		textDisplay.MovementHintChannel = payload;
	}
}
