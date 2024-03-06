using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class AppFlow : CoroutineFsm
{
	[Editor] bool skipIntro;

	protected override Func<IEnumerator> Entry => LoadGame;

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

		Locator.State.SuppressPlayer = true;

		var cutscene = Locator.Cutscenes.GameStart;
		cutscene.Play();

		{
			var wait = true;
			cutscene.Finished += () => wait = false;
			yield return new WaitWhile(() => wait);
		}

		Locator.State.SuppressPlayer = false;

		yield return TransitionTo(FreeRoam);
	}

	private IEnumerator FreeRoam()
	{
		yield break;
	}
}
