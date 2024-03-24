using System;
using System.Collections;
using UnityEngine;

public class AppState
{
	public bool SuppressPlayer = false;
	public bool IsPlayingCutscene = false;
	public Cutscene PendingInteraction = null;

	public Vector3 PlayerPosition;
	public float DistanceTraveled;
	public bool IsInteractionHovered;

	// no signal bus no life
	public Action InteractPressed;
	public Action<InteractionHandle> InteractionTriggered;
	public Action LanguageChanged;

	public void InvokeInteractionTriggered(InteractionHandle message)
		=> InteractionTriggered?.Invoke(message);

	public void InvokeInteractPressed()
		=> InteractPressed?.Invoke();
		
	public void InvokeLanguageChanged()
		=> LanguageChanged?.Invoke();
	
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