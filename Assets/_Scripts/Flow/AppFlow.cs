using System;
using System.Collections;
using System.Collections.Generic;
using DevLocker.Utils;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Editor = UnityEngine.SerializeField;

public class AppFlow : MonoBehaviour
{
	[Editor] SceneReference roomScene;

	[Editor] MenuFlow mainMenu;
	[Editor] EndingsFlow endings;

	[Editor] bool skipMenu;
	[Editor] bool skipIntro;
	[Editor] bool skipInteractions;
	[Range(1, 10)]
	[Editor] int gameSpeed = 1;

	// a-la [Inject] fields
	private AppState state => Locator.State;
	private CutscenesContainer cutscenes => Locator.Cutscenes;
	private BgmStartService bgm => Locator.Bgm;
	private CursorService cursor => Locator.Cursor;
	
	
	private bool hasMoreInteractions => Locator.RouteTracker.HasInteractionsLeft;

	private void Start()
	{
		StartCoroutine(Flow());
	}

	private IEnumerator Flow()
	{
		// LOAD ROOM / INIT
		#if UNITY_EDITOR
		Time.timeScale = gameSpeed;
		#endif

		// pre-intro hack
		state.SuppressPlayer = true;

		// MAIN MENU
		SetCursor(isHidden: false);

		#if UNITY_EDITOR
		if (!skipMenu)
		#endif
		{
			yield return mainMenu.MenuSequence();
		}

		// INTRO CUTSCENE
		SetCursor(isHidden: true);
		bgm.Run();

		#if UNITY_EDITOR
		if (!skipIntro)
		#endif
		{
			yield return LockPlayerAnd(cutscenes.Intro.PlayAndWait);
		}

		state.SuppressPlayer = false; // editor mode related hack
		
		// GAME LOOP
		while (hasMoreInteractions)
		{
			InteractionHandle next = null;
			yield return state.WaitForInteraction(
				ret => next = ret
			);
			yield return InteractionCutscene(next);
		}

		// FINAL CUTSCENE
		yield return endings.RouteEnding();

		// Reload()
		Locator.Clear();
		SceneManager.LoadScene(roomScene.ScenePath);
	}

	private IEnumerator InteractionCutscene(InteractionHandle interaction)
	{
		var cutscene = cutscenes.CutsceneOf(interaction);
		
		#if UNITY_EDITOR
		if (!skipInteractions)
		#endif
		{
			yield return LockPlayerAnd(cutscene.PlayAndWait);
		}

		state.InvokeInteractionFinished();
	}

	private void SetCursor(bool isHidden)
	{
		cursor.PreferHidden = isHidden;

		// Cursor.visible = !isLocked;
		// Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
	}

	private IEnumerator LockPlayerAnd(Func<IEnumerator> routine)
	{
		state.SuppressPlayer = true;
		yield return routine();
		state.SuppressPlayer = false;
	}
}
