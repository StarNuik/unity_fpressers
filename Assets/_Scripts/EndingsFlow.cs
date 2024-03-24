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
		yield break;
	}

	public IEnumerator ReverseEnding()
	{
		yield return cutscenes.BeforeEnding.PlayAndWait();

		reverseEndingInteraction.Enable();
		yield return state.WaitForInteractionAndUpdate(
			ret => Assert.IsTrue(reverseEndingInteraction == ret),
			() => { mixer.PushBgmFx(1f); mixer.PushBgmDuck(1f); }
		);

		yield return cutscenes.ReverseEnding.PlayAndWait();
	}
}
