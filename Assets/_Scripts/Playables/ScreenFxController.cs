using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class ScreenFxController : MonoBehaviour
{
	[Editor] MeshRenderer renderer;

	private ReplacedMaterial material;

	public static void ApplyTo(Material material, float emission)
	{
		var color = Color.Lerp(Color.black, Color.white, emission);
		material.SetColor("_EmissionColor", color);
	}

	private void OnEnable()
	{
		material = new(() => renderer.sharedMaterial, val => renderer.sharedMaterial = val);
	}

	private void OnDisable()
	{
		material.Return();
	}

	private void Update()
	{
		var f = Locator.State.ScreenEmission;
		ApplyTo(material, f);
	}
}
