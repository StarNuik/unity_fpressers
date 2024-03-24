using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Route = EndingRouteService.RouteType;

public class EndingsFlow : MonoBehaviour
{
	private EndingRouteService routes => Locator.RouteTracker;
	private CutscenesContainer cutscenes => Locator.Cutscenes;

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
		yield break;
	}
}
