using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Editor = UnityEngine.SerializeField;

[ExecuteInEditMode]
public class ShaderSauceController : MonoBehaviour
{
	[Editor] RenderObjects target;
	[Editor] Material matOriginal;

	public float Strength { get; set; } = 0f;
	public float FogMilkRatio { get; set; } = 0f;

	private Material mat;

	// should work in Edit Mode as well
	public void Apply()
	{
		if (mat == null)
		{
			mat = new(matOriginal);
			target.settings.overrideMaterial = mat;
		}

		mat.SetFloat("_Strength", Strength);
		mat.SetFloat("_FogMilkRatio", FogMilkRatio);
	}

	private void OnDestroy()
	{
		if (mat == null)
			return;

		Action<UnityEngine.Object> destroy = Application.isPlaying ? Destroy : DestroyImmediate;		
		destroy(mat);
		target.settings.overrideMaterial = matOriginal;
	}
}
