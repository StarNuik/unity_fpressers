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

		yield return PlayAndWaitCutscene(Locator.Cutscenes.GameStart);

		yield return TransitionTo(FreeRoam);
	}

	private IEnumerator FreeRoam()
	{
		var @true = true;
		while (@true)
		{
			yield return null;

			if (Locator.State.PendingInteraction != null)
			{
				yield return TransitionTo(InteractionCutscene);
				yield break;
			}
		}
	}

	private IEnumerator InteractionCutscene()
	{
		yield return PlayAndWaitCutscene(state.PendingInteraction);

		state.PendingInteraction = null;

		yield return TransitionTo(FreeRoam);
	}

	// helpers
	private IEnumerator PlayAndWaitCutscene(Cutscene cutscene)
	{
		state.SuppressPlayer = true;

		yield return cutscene.PlayAndWait();

		state.SuppressPlayer = false;
	}
}
