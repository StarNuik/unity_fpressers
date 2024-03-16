using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

// very similar to `ShaderSauceController.cs`
[ExecuteInEditMode]
public class PcScreenMaterialController : MonoBehaviour
{
	[Editor] MeshRenderer target;
	[Editor] Material matOriginal;

	public Props Properties { private get; set; }

	private Material mat;

	public void Apply()
	{
		if (mat == null)
		{
			mat = new(matOriginal);

			target.sharedMaterial = mat;
		}

		mat.SetTexture("_EmissionMap", Properties.EmissionMap);

		var color = Color.Lerp(Color.black, Color.white, Properties.EmissionStrength);
		mat.SetColor("_EmissionColor", color);
	}

	private void OnDestroy()
	{
		if (mat == null)
			return;

		Action<UnityEngine.Object> destroy = Application.isPlaying ? Destroy : DestroyImmediate;
		destroy(mat);
		mat = null;

		if (target != null)
			target.sharedMaterial = matOriginal;
	}

	public struct Props
	{
		public Texture2D EmissionMap;
		public float EmissionStrength;
	}
}
