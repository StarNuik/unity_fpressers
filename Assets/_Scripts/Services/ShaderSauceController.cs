using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Editor = UnityEngine.SerializeField;

// very similar to `PcScreenMaterialController.cs`
[ExecuteInEditMode]
public class ShaderSauceController : MonoBehaviour
{
	[Editor] ScriptableRendererData targetParent;
	[Editor] FullScreenPassRendererFeature target;
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
			SetFeatureMaterial(mat);
		}

		mat.SetFloat("_Strength", Strength);
		// mat.SetFloat("_FogMilkRatio", FogMilkRatio);
	}

	private void OnDestroy()
	{
		if (mat == null)
			return;

		Action<UnityEngine.Object> destroy = Application.isPlaying ? Destroy : DestroyImmediate;
		destroy(mat);
		mat = null;

		SetFeatureMaterial(matOriginal);
	}

	private void SetFeatureMaterial(Material material)
	{
		target.passMaterial = material;
		targetParent.SetDirty();
	}
}
