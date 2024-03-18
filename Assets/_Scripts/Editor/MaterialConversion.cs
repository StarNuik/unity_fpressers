using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialConversion
{
	public struct MaterialProperties
	{
		public MaterialHelper.SurfaceType SurfaceType;
		
		public Color AlbedoColor;
		public Color EmissionColor;
		
		public float Smoothness;
		public float Metallic;
	}

	public static MaterialProperties FromGltf(Material source)
	{
		var p = new MaterialProperties();
		p.SurfaceType = MaterialHelper.GetSurfaceType(source);

		p.AlbedoColor = source.GetColor("baseColorFactor");
		p.EmissionColor = source.GetColor("emissiveFactor");

		p.Smoothness = Mathf.Clamp01(1f - source.GetFloat("roughnessFactor"));
		p.Metallic = source.GetFloat("metallicFactor");
		return p;
	}

	public static MaterialProperties FromUrp(Material source)
	{
		var p = new MaterialProperties();
		p.SurfaceType = MaterialHelper.GetSurfaceType(source);

		p.AlbedoColor = source.GetColor("_BaseColor");
		p.EmissionColor = source.GetColor("_EmissionColor");

		p.Smoothness = source.GetFloat("_Smoothness");
		p.Metallic = source.GetFloat("_Metallic");
		return p;
	}

	public static void ApplyToUrp(Material target, MaterialProperties props)
	{
		MaterialHelper.SetTransparent(target, props.SurfaceType);

		target.SetColor("_BaseColor", props.AlbedoColor);
		target.SetColor("_EmissionColor", props.EmissionColor);

		target.SetFloat("_Smoothness", props.Smoothness);
		target.SetFloat("_Metallic", props.Metallic);
	}

	public static void ApplyToUrpSimple(Material target, MaterialProperties props)
	{
		target.SetFloat("_SpecularHighlights", 0f);
		MaterialHelper.SetTransparent(target, props.SurfaceType);

		target.SetColor("_BaseColor", props.AlbedoColor);
		target.SetColor("_EmissionColor", props.EmissionColor);

		target.SetFloat("_Smoothness", props.Smoothness);
		// target.SetFloat("_Metallic", props.Metallic);
	}
}
