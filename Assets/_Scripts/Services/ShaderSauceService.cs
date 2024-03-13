using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

[ExecuteInEditMode]
public class ShaderSauceService : MonoBehaviour
{
	[Editor] ShaderSauceController shader;

	private Request? timelineReq;
	private Request? splashReq;
	private Request? freeroamReq;

	// these 3 (they became 4) could be replaced either with a `enum` or an `int priority`
	// Dictionary<enum, Request> def sounds like the nicest solution
	#region public Requests
	public void PushSplash(float strength, float fogMilkRatio)
		=> splashReq = new(strength, fogMilkRatio);
	
	public void PushFreeroam(float strength, float fogMilkRatio)
		=> freeroamReq = new(strength, fogMilkRatio);

	// this is starting to become hacky
	public void PushTimelineStrength(float strength)
	{
		var req = timelineReq.GetValueOrDefault();
		req.Strength = strength;
		timelineReq = req;
	}

	public void PushTimelineRatio(float fogMilkRatio)
	{
		var req = timelineReq.GetValueOrDefault();
		req.FogMilkRatio = fogMilkRatio;
		timelineReq = req;
	}
	#endregion

	#region	Unity messages
	private void Awake()
	{
		Locator.ShaderSauce = this;
	}

	private void LateUpdate()
	{
		var vals = ChooseRequest();
		shader.Strength = vals.Strength;
		shader.FogMilkRatio = vals.FogMilkRatio;
		shader.Apply();

		ClearRequests();
	}
	#endregion

	private Request ChooseRequest()
	{
		if (timelineReq.HasValue) return timelineReq.Value;
		if (splashReq.HasValue) return splashReq.Value;
		if (freeroamReq.HasValue) return freeroamReq.Value;
		return new();
	}

	private void ClearRequests()
	{
		timelineReq = null;
		splashReq = null;
		freeroamReq = null;
	}

	private struct Request
	{
		public float Strength;
		public float FogMilkRatio;

		public Request(float strength, float fogMilkRatio)
		{
			Strength = strength;
			FogMilkRatio = fogMilkRatio;
		}
	}

}
