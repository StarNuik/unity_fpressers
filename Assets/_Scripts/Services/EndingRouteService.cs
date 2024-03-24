using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class EndingRouteService : MonoBehaviour
{
	[Editor] List<InteractionHandle> RouteOrder = new();
	
	// these 2 props are orphans (they kind of don't belong here)
	public bool HasInteractedOnce => currentRoute.Count > 0;
	public bool HasInteractionsLeft => currentRoute.Count < RouteOrder.Count;
	public RouteType CurrentRoute { get; private set; }

	private List<InteractionHandle> currentRoute = new();

	private void Awake()
	{
		Locator.RouteTracker = this;
		Locator.State.InteractionTriggered += UpdateRoute;
	}

	private void UpdateRoute(InteractionHandle handle)
	{
		// this allows me to have interactions outside of the Route system
		if (!RouteOrder.Contains(handle))
			return;
		
		Debug.Log($"[ EndingRouteService.UpdateRoute ] unityId: {this.GetInstanceID()}, currentRoute.Count: {currentRoute.Count}");
		currentRoute.Add(handle);

		CurrentRoute = RouteType.Neutral;
		TestForCorrectRoute();
		TestForReversedRoute();
	}

	private void TestForCorrectRoute()
	{
		var isRoute = true;
		for (int i = 0; i < currentRoute.Count; i++)
		{
			isRoute &= currentRoute[i] == RouteOrder[i];
		}

		if (isRoute)
		{
			CurrentRoute = RouteType.Correct;
		}
	}

	private void TestForReversedRoute()
	{
		var orderLast = RouteOrder.Count - 1;
		var isRoute = true;
		for (int i = 0; i < currentRoute.Count; i++)
		{
			isRoute &= currentRoute[i] == RouteOrder[orderLast - i];
		}

		if (isRoute)
		{
			CurrentRoute = RouteType.Reversed;
		}
	}

	public enum RouteType
	{
		Neutral,
		Correct,
		Reversed,
	}
}
