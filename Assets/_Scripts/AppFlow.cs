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

	// a-la [Inject] fields
	private AppState state => Locator.State;
	private SplashSequence splash => Locator.Splash;
	private CutscenesContainer cutscenes => Locator.Cutscenes;
	private BgmStartService bgm => Locator.Bgm;
	private InputService input => Locator.Input;
	
	private bool hasMoreInteractions => Locator.RouteTracker.HasInteractionsLeft;

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
			yield return splash.FadeIn();

			// not a hack \s
			yield return new WaitUntil(() => input.IsInteractUp);

			splash.Disable();
		}

		SetTransition(IntroCutscene);
	}

	private IEnumerator IntroCutscene()
	{
		bgm.Run();

		#if UNITY_EDITOR
		if (!skipIntro)
		#endif
		{
			yield return PlayAndWaitCutscene(cutscenes.Intro);
		}

		state.SuppressPlayer = false; // an unnecessary, editor mode related action
		SetTransition(FreeRoam);
	}

	private IEnumerator FreeRoam()
	{
		while (hasMoreInteractions)
		{
			InteractionHandle next = null;
			yield return state.WaitForInteraction(
				ret => next = ret
			);
			yield return InteractionCutscene(next);
		}

		SetTransition(MainEnding);
	}

	private IEnumerator InteractionCutscene(InteractionHandle interaction)
	{
		var cutscene = cutscenes.CutsceneOf(interaction);
		
		#if UNITY_EDITOR
		if (!skipInteractions)
		#endif
		{
			yield return PlayAndWaitCutscene(cutscene);
		}
	}

	private IEnumerator MainEnding()
	{
		// the lack of player suppression is on purpose
		yield return cutscenes.NeutralEnding.PlayAndWait();

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
