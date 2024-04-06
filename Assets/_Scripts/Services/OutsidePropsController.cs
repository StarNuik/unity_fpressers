using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	private void Awake()
	{
		// implicit clone
		matTarget = quadMesh.material;
		
		TargetFrame = 0;
	}

	private void Update()
	{
		var nextF = lastF + mixDelta;
		
		sunLight.transform
			.Lerp(from.SunTransform, to.SunTransform, nextF);
		matTarget.SetColor("_BaseColor",
			Color.Lerp(from.QuadColor, to.QuadColor, nextF)
		);
		sunLight.colorTemperature = 
			Mathf.Lerp(from.SunTemperature, to.SunTemperature, nextF);
		indoorsLight.colorTemperature =
			Mathf.Lerp(from.IndoorsTemperature, to.IndoorsTemperature, nextF);
		
		lastF = nextF;
	}

	[Serializable]
	private class Keyframe
	{
		public Color QuadColor;
		public Transform SunTransform;
		public float SunTemperature;
		public float IndoorsTemperature;
	}
}
