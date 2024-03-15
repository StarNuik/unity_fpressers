using System;
using System.Collections;
using UnityEngine;
using Monologue = MonologuesContainer.MonologueInfo;

public class AppState
{
	public bool SuppressPlayer = false;
	public bool IsPlayingCutscene = false;
	public Cutscene PendingInteraction = null;

	public float ScreenEmission = 0f;
	public Vector3 PlayerPosition;
	public float DistanceTraveled;

	// no signal bus no life
	public Action<InteractionHandle> InteractionTriggered;
	public Action<InteractionHandle> InteractionHovered;

	public void InvokeInteractionTriggered(InteractionHandle message)
		=> InteractionTriggered?.Invoke(message);
	
	public void InvokeInteractionHovered(InteractionHandle message)
		=> InteractionHovered?.Invoke(message);

	public IEnumerator WaitForInteraction(Action<InteractionHandle> returner)
	{
		var wait = true;
		Action<InteractionHandle> callback = val =>
		{
			wait = false;
			returner(val);
		};

		InteractionTriggered += callback;
		yield return new WaitWhile(() => wait);
		InteractionTriggered -= callback;
	}
}