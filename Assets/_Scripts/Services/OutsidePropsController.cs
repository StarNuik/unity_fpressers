using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Editor = UnityEngine.SerializeField;

public class OutsidePropsController : MonoBehaviour
{
	[Editor] MeshRenderer quadMesh;
	[Editor] Light sunLight;
	[Editor] Light indoorsLight;
	[Editor] float mixDuration = 1f;
	[Editor] List<Keyframe> frames = new();

	public int TargetFrame
	{
		set
		{
			var idx = Mathf.Clamp(value, 0, frames.Count - 1);
			
			if (value == lastFrame)
				return;
			
			from = to;
			to = frames[idx];
			lastF = 0f;

			lastFrame = idx;
		}
	}
	
	private float mixDelta => 1f / mixDuration * Time.deltaTime;

	private Material matTarget;
	private Keyframe from;
	private Keyframe to;
	private float lastF;
	private int lastFrame = -1;
	private float startSun; // intensity
	private float startIndoors; // intensity

	private void Awake()
	{
		// implicit clone
		matTarget = quadMesh.material;
		startSun = sunLight.intensity;
		startIndoors = indoorsLight.intensity;

		// questionable but quick setup
		from = frames[0];
		to = frames[0];
		TargetFrame = 0;
	}

	private void Update()
	{
		var nextF = lastF + mixDelta;
		
		matTarget.SetColor("_BaseColor",
			Color.Lerp(from.QuadColor, to.QuadColor, nextF)
		);

		sunLight.transform
			.Lerp(from.SunTransform, to.SunTransform, nextF);

		var duckF = to.IntensityCurve.Evaluate(nextF);
		SetLightProps(sunLight,
			nextF, duckF,
			startSun,
			from.SunTemperature, to.SunTemperature,
			from.SunDuck, to.SunDuck);
		SetLightProps(indoorsLight,
			nextF, duckF,
			startIndoors,
			from.IndoorsTemperature, to.IndoorsTemperature,
			from.IndoorsDuck, to.IndoorsDuck);
		
		lastF = nextF;
	}

	private void SetLightProps(
		Light light,
		float f, float duckF,
		float startIntensity,
		float fromTemp, float toTemp,
		float fromDuck, float toDuck
	)
	{
		light.colorTemperature = Mathf.Lerp(fromTemp, toTemp, f);

		var fIntensity = Mathf.Lerp(fromDuck, toDuck, duckF);
		light.intensity = Mathf.Lerp(startIntensity, 0f, fIntensity);
	}

	[Serializable]
	private class Keyframe
	{
		public Color QuadColor;
		public Transform SunTransform;
		[Range(0f, 1f), FormerlySerializedAs("SunIntensityDuck")]
		public float SunDuck;
		public float SunTemperature;
		public float IndoorsTemperature;
		[Range(0f, 1f), FormerlySerializedAs("IndoorsIntensityDuck")]
		public float IndoorsDuck;
		[CurveRange(0f, 0f, 1f, 1f)]
		public AnimationCurve IntensityCurve;
	}
}
