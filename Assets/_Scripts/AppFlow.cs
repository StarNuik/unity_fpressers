using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Editor = UnityEngine.SerializeField;

public class AppFlow : CoroutineFsm
{
	[Editor] bool skipSplash;
	[Editor] bool skipIntro;
	[Editor] bool skipInteractions;
	[Range(1, 10)]
	[Editor] int gameSpeed = 1;

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
		#if UNITY_EDITOR
		Time.timeScale = gameSpeed;
		#endif

		// pre-intro hack
		state.SuppressPlayer = true;

		SetTransition(Splash);
		yield break;
	}

	private IEnumerator Splash()
	{
		SetCursor(isLocked: false);

		#if UNITY_EDITOR
		if (!skipSplash)
		#endif
		{
			yield return splash.FadeIn();

			// not a hack \s
			yield return new WaitUntil(() => input.IsInteractUp);

			yield return splash.Disable();
		}

		SetTransition(IntroCutscene);
	}

	private IEnumerator IntroCutscene()
	{
		SetCursor(isLocked: true);
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
		Locator.Clear();
		SceneManager.LoadScene(0);
		yield break;
	}

	private IEnumerator PlayAndWaitCutscene(Cutscene cutscene)
	{
		state.SuppressPlayer = true;
		yield return cutscene.PlayAndWait();
		state.SuppressPlayer = false;
	}

	private void SetCursor(bool isLocked)
	{
		Cursor.visible = !isLocked;
		Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
	}
}
