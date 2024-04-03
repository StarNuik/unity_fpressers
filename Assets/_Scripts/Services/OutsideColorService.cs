using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class OutsideColorService : MonoBehaviour
{
	[Editor] MeshRenderer meshTarget;
	[Editor] Light outside;
	[Editor] Light inside;
	[Min(0f)]
	[Editor] float mixDuration = 1f;
	// [ColorUsage(showAlpha: false, hdr: true)]
	[Editor] List<Infos> targets = new();

	private Material matTarget;
	private Infos from;
	private Infos to;
	private float lastF;

	private Color matColor
	{
		set => matTarget.SetColor("_BaseColor", value);
	}

	private float outsideTemp
	{
		set => outside.colorTemperature = value;
	}

	private float insideTemp
	{
		set => inside.colorTemperature = value;
	}

	private float mixDelta => 1f / mixDuration * Time.deltaTime;

	private AppState state => Locator.State;
	private EndingRouteService route => Locator.RouteTracker;

	private void Awake()
	{
		// state.InteractionFinished += UpdateTarget;

		// implicit clone
		matTarget = meshTarget.material;

		to = targets[0];
		from = to;
		matColor = to.Color;
		outsideTemp = to.OutsideTemperature;
		insideTemp = to.InsideTemperature;
	}

	private void Update()
	{
		var nextF = lastF + mixDelta;
		matColor = Color.Lerp(from.Color, to.Color, nextF);
		outsideTemp = Mathf.Lerp(from.OutsideTemperature, to.OutsideTemperature, nextF);
		insideTemp = Mathf.Lerp(from.InsideTemperature, to.InsideTemperature, nextF);
		
		lastF = nextF;
	}

	private int index = 0;
	[Button]
	private void Increment()
	{
		index++;
		UpdateTarget();
	}

	private void UpdateTarget()
	{
		// var index = route.TimesInteracted;
		if (index >= targets.Count)
			return;
		
		var next = targets[index];
		from = to;
		to = next;
		lastF = 0f;
	}

	[Serializable]
	private class Infos
	{
		public Color Color;
		public float OutsideTemperature;
		public float InsideTemperature;
	}
}
