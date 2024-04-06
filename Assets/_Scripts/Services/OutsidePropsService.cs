using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class OutsidePropsService : MonoBehaviour
{
	[Editor] OutsidePropsController driver;

	private AppState state => Locator.State;
	private EndingRouteService route => Locator.RouteTracker;

	private void Awake()
	{
		state.InteractionFinished += UpdateTarget;
	}

	private void UpdateTarget()
	{
		var index = route.TimesInteracted;
		driver.TargetFrame = index;
	}
}
