using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppFlow : CoroutineFsm
{
	protected override Func<IEnumerator> Entry => LoadGame;

	private IEnumerator LoadGame()
	{
		Locator.State = new();

		yield return TransitionTo(StartCutscene);
	}

	private IEnumerator StartCutscene()
	{
		Locator.State.SuppressPlayer = true;
		Debug.Log("[AppFlow.StartCutscene] entry");

		var cutscene = Locator.Cutscenes.GameStart;
		cutscene.Play();

		{
			var wait = true;
			cutscene.Finished += () => wait = false;
			yield return new WaitWhile(() => wait);
		}

		Debug.Log("[AppFlow.StartCutscene] exit");
		Locator.State.SuppressPlayer = false;
	}

	private IEnumerator FreeRoam()
	{
		yield break;
	}
}
