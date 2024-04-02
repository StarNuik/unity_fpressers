using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class OutsideColorService : MonoBehaviour
{
	[Editor] MeshRenderer meshTarget;
	[Min(0f)]
	[Editor] float mixDuration = 1f;
	[ColorUsage(showAlpha: false, hdr: true)]
	[Editor] List<Color> colorTargets = new() { Color.white, };

	private Material matTarget;
	private Color colFrom;
	private Color colTo;
	private float lastF;

	private Color matColor
	{
		get => matTarget.GetColor("_EmissionColor");
		set => matTarget.SetColor("_EmissionColor", value);
	}

	private float mixDelta => 1f / mixDuration * Time.deltaTime;

	private AppState state => Locator.State;
	private EndingRouteService route => Locator.RouteTracker;

	private void Awake()
	{
		state.InteractionFinished += UpdateTarget;

		// implicit clone
		matTarget = meshTarget.material;

		colTo = colorTargets[0];
		colFrom = colTo;
		matColor = colTo;
	}

	private void Update()
	{
		var nextF = lastF + mixDelta;
		matColor = Color.Lerp(colFrom, colTo, nextF);
		lastF = nextF;
	}

	private void UpdateTarget()
	{
		var index = route.TimesInteracted;
		if (index >= colorTargets.Count)
			return;
		
		var next = colorTargets[index];
		colFrom = colTo;
		colTo = next;
		lastF = 0f;
	}
}
