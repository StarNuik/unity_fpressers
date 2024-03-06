using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;
using Editor = UnityEngine.SerializeField;

public class MilkFxController : MonoBehaviour
{
	[Editor] RenderObjects milkFx;

	private Material lastMaterial;
	private Material currentMaterial;
	
	public static void ApplyTo(Material target, float strength, float ratio)
	{
		if (target == null)
			return;

		target.SetFloat("_Strength", strength);
		target.SetFloat("_FogMilkRatio", ratio);
	}

	private void OnEnable()
	{
		lastMaterial = milkFx.settings.overrideMaterial;
		currentMaterial = new(lastMaterial);
		milkFx.settings.overrideMaterial = currentMaterial;
	}

	private void OnDisable()
	{
		milkFx.settings.overrideMaterial = lastMaterial;
	}

	private void LateUpdate()
	{
		var state = Locator.State;
		ApplyTo(currentMaterial, state.MilkStrength, state.FogMilkRatio);
	}
}
