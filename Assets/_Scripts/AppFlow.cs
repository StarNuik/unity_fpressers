using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Editor = UnityEngine.SerializeField;

public class AppFlow : CoroutineFsm
{
	[Editor] bool skipIntro;

	protected override Func<IEnumerator> Entry => LoadGame;

	private AppState state => Locator.State;
	private int interactionsLeft => Locator.InteractionHandles.Count;

	private IEnumerator LoadGame()
	{
		SetTransition(IntroCutscene);
		yield break;
	}

	private IEnumerator IntroCutscene()
	{
		#if UNITY_EDITOR
		if (skipIntro)
		{
			SetTransition(FreeRoam);
			yield break;
		}
		#endif

		yield return PlayAndWaitCutscene(Locator.Cutscenes.Intro);

		SetTransition(FreeRoam);
	}

	private IEnumerator FreeRoam()
	{
		Locator.ShaderSauce.Enable(interactionsLeft);

		while (interactionsLeft > 0)
		{
			yield return null;

			// technically, this is a sub-fsm
			if (Locator.State.PendingInteraction != null)
			{
				yield return InteractionCutscene();
			}
		}

		SetTransition(MainEnding);
	}

	private IEnumerator InteractionCutscene()
	{
		yield return PlayAndWaitCutscene(state.PendingInteraction);

		state.PendingInteraction = null;
	}

	private IEnumerator MainEnding()
	{
		// the lack of player suppression is on purpose
		yield return Locator.Cutscenes.MainEnding.PlayAndWait();

		SetTransition(Reload);
	}

	private IEnumerator Reload()
	{
		SceneManager.LoadScene(0);
		yield break;
	}

	// helpers
	private IEnumerator PlayAndWaitCutscene(Cutscene cutscene)
	{
		state.SuppressPlayer = true;

		yield return cutscene.PlayAndWait();

		state.SuppressPlayer = false;
	}
}
