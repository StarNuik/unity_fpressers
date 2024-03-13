using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Editor = UnityEngine.SerializeField;

public class AppFlow : CoroutineFsm
{
	[Editor] bool skipSplash;
	[Editor] bool skipIntro;
	[Editor] bool skipInteractions;

	protected override Func<IEnumerator> Entry => LoadApp;

	private AppState state => Locator.State;
	private int interactionsLeft => Locator.InteractionHandles.Count;

	private IEnumerator LoadApp()
	{
		// pre-intro hack
		state.SuppressPlayer = true;

		SetTransition(Splash);
		yield break;
	}

	private IEnumerator Splash()
	{
		#if UNITY_EDITOR
		if (!skipSplash)
		#endif
		{
			var splash = Locator.Splash;
			splash.Enable();
			yield return splash.ClearSplash();

			// not a hack \s
			yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.F));

			yield return splash.ClearText();
			splash.Disable();
		}

		SetTransition(IntroCutscene);
	}

	private IEnumerator IntroCutscene()
	{
		Locator.Bgm.Run();

		#if UNITY_EDITOR
		if (!skipIntro)
		#endif
		{
			yield return PlayAndWaitCutscene(Locator.Cutscenes.Intro);
		}

		state.SuppressPlayer = false; // an unnecessary, editor mode related action
		SetTransition(FreeRoam);
	}

	private IEnumerator FreeRoam()
	{
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
		var cutscene = state.PendingInteraction;

		#if UNITY_EDITOR
		if (!skipInteractions)
		#endif
		{
			yield return PlayAndWaitCutscene(cutscene);
		}

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

	private IEnumerator PlayAndWaitCutscene(Cutscene cutscene)
	{
		state.SuppressPlayer = true;
		yield return cutscene.PlayAndWait();
		state.SuppressPlayer = false;
	}
}
