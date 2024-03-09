using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

public class Cutscene : MonoBehaviour
{
	[Editor] PlayableDirector track;

	private AppState state => Locator.State;

	public IEnumerator PlayAndWait()
	{
		Assert.IsTrue(!state.IsPlayingCutscene, "[ Cutscene.PlayAndWait() ] Assert.IsTrue(!state.IsPlayingCutscene)");

		state.IsPlayingCutscene = true;
		track.Play();

		var wait = true;
		track.stopped += _ => wait = false;
		yield return new WaitWhile(() => wait);
		state.IsPlayingCutscene = false;
	}
}
