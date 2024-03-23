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
		Action<PlayableDirector> action = _ => wait = false;
		
		track.stopped += action;
		yield return new WaitWhile(() => wait);
		track.stopped -= action;
		
		state.IsPlayingCutscene = false;
	}
}
