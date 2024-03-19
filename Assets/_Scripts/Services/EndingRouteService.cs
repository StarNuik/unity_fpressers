using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class EndingRouteService : MonoBehaviour
{
	[Editor] List<InteractionHandle> RouteOrder = new();
	
	// these 2 props is an orphan (it actually belongs to a non-existent EndingService)
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
		currentRoute.Add(handle);

		CurrentRoute = RouteType.Neutral;
		TestForCorrectRoute();
		TestForReversedRoute();
	}

	private void TestForCorrectRoute()
	{
		var correct = true;
		for (int i = 0; i < currentRoute.Count; i++)
		{
			correct &= currentRoute[i] == RouteOrder[i];
		}

		if (correct)
		{
			CurrentRoute = RouteType.Correct;
		}
	}

	private void TestForReversedRoute()
	{}

	public enum RouteType
	{
		Neutral,
		Correct,
		Reversed,
	}
}
