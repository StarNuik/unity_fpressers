using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Route = EndingRouteService.RouteType;
using Editor = UnityEngine.SerializeField;
using DG.Tweening;
using UnityEngine.Assertions;

public class EndingsFlow : MonoBehaviour
{
	// a nasty hack
	[Editor] TextAsset finalInteractionText;
	[Editor] InteractionHandle reverseEndingInteraction;
	[Editor] InteractionHandle correctEndingInteraction;

	private EndingRouteService routes => Locator.RouteTracker;
	private CutscenesContainer cutscenes => Locator.Cutscenes;
	private AudioMixerService mixer => Locator.AudioMixer;
	private BgmStartService bgm => Locator.Bgm;
	private AppState state => Locator.State;
	private RecordSpin record => Locator.RecordSpin;

	public IEnumerator RouteEnding()
	{
		Func<IEnumerator> routine = routes.CurrentRoute switch {
			Route.Correct => CorrectEnding,
			Route.Reversed => ReverseEnding,
			_ => NeutralEnding,
		};

		yield return routine();
	}

	public IEnumerator NeutralEnding()
	{
		// the lack of player suppression is on purpose
		yield return cutscenes.NeutralEnding.PlayAndWait();
	}

	public IEnumerator CorrectEnding()
	{
		yield return BeforeEnding(correctEndingInteraction);
		yield return cutscenes.CorrectEnding.PlayAndWait();
	}

	public IEnumerator ReverseEnding()
	{
		yield return BeforeEnding(reverseEndingInteraction);
		yield return cutscenes.ReverseEnding.PlayAndWait();
	}

	private IEnumerator BeforeEnding(InteractionHandle finalInteraction)
	{
		yield return cutscenes.BeforeEnding.PlayAndWait();
		bgm.Stop();
		record.Destroy();

		finalInteraction.Enable();
		yield return state.WaitForInteractionAndUpdate(
			ret => Assert.IsTrue(ret == finalInteraction),
			() => { mixer.PushBgmFx(1f); mixer.PushBgmDuck(1f); }
		);
		
	}
}
