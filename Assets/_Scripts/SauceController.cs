using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Editor = UnityEngine.SerializeField;

[CreateAssetMenu(menuName = "SOs/Sauce Controller")]
public class SauceController : ScriptableObject
{
	[Editor] RenderObjects target;

	public float Strength { get; set; } = 0f;
	public float FogMilkRatio { get; set; } = 0f;

	public void Apply()
	{
		var material = target.settings.overrideMaterial;

		material.SetFloat("_Strength", Strength);
		material.SetFloat("_FogMilkRatio", FogMilkRatio);
	}
}
