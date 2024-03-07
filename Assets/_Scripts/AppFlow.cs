using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class AppFlow : CoroutineFsm
{
	[Editor] bool skipIntro;

	protected override Func<IEnumerator> Entry => LoadGame;

	private AppState state => Locator.State;
	private int interactionsLeft => Locator.InteractionHandles.Count;

	private IEnumerator LoadGame()
	{
		yield return TransitionTo(IntroCutscene);
	}

	private IEnumerator IntroCutscene()
	{
		#if UNITY_EDITOR
		if (skipIntro)
		{
			yield return TransitionTo(FreeRoam);
			yield break;
		}
		#endif

		yield return PlayAndWaitCutscene(Locator.Cutscenes.Intro);

		yield return TransitionTo(FreeRoam);
	}

	private IEnumerator FreeRoam()
	{
		while (interactionsLeft > 0)
		{
			yield return null;

			// technically, this is a sub-fsm
			if (Locator.State.PendingInteraction != null)
			{
				yield return TransitionTo(InteractionCutscene);
				yield break;
			}
		}

		yield return TransitionTo(MainEnding);
	}

	private IEnumerator InteractionCutscene()
	{
		yield return PlayAndWaitCutscene(state.PendingInteraction);

		state.PendingInteraction = null;

		yield return TransitionTo(FreeRoam);
	}

	private IEnumerator MainEnding()
	{
		Debug.Log("HEllo edning");
		// the lack of player suppression is on purpose
		yield return Locator.Cutscenes.MainEnding.PlayAndWait();
	}

	// helpers
	private IEnumerator PlayAndWaitCutscene(Cutscene cutscene)
	{
		state.SuppressPlayer = true;

		yield return cutscene.PlayAndWait();

		state.SuppressPlayer = false;
	}
}
