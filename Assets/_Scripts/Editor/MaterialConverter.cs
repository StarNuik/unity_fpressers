using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System;
using MatProps = MaterialConversion.MaterialProperties;

public static class MaterialConverter
{
	private static Shader gltfShader => Shader.Find("Shader Graphs/glTF-pbrMetallicRoughness");
	private static Shader urpShader => Shader.Find("Universal Render Pipeline/Lit");
	private static Shader urpSimpleShader => Shader.Find("Universal Render Pipeline/Simple Lit");
	private static Shader builtinShader => Shader.Find("Standard");

	[MenuItem("Assets/Convert Material/gltf Pbr -> Urp Lit")]
	public static void GltfToUrp()
		=> TransformSelectedMaterials(
			withShader: gltfShader,
			targetShader: urpSimpleShader,
			reducer: MaterialConversion.FromGltf,
			builder: MaterialConversion.ApplyToUrp,
			debugTag: "GltfToUrp"
		);
	
	[MenuItem("Assets/Convert Material/Urp Lit -> Urp Simple Lit")]
	public static void UrpToUrpSimple()
		=> TransformSelectedMaterials(
			withShader: urpShader,
			targetShader: urpSimpleShader,
			reducer: MaterialConversion.FromUrp,
			builder: MaterialConversion.ApplyToUrpSimple,
			debugTag: "UrpToUrpSimple"
		);

	[MenuItem("Assets/Convert Material/Urp Lit -> Standard")]
	public static void UrpToStandard()
		=> TransformSelectedMaterials(
			withShader: urpShader,
			targetShader: builtinShader,
			reducer: MaterialConversion.FromUrp,
			builder: MaterialConversion.ApplyToBuiltin,
			debugTag: "UrpToStandard"
		);
	
	

	private static void TransformSelectedMaterials(
		Shader withShader,
		Shader targetShader,
		Func<Material, MatProps> reducer,
		Action<Material, MatProps> builder,
		string debugTag = "ForEachMat")
	{
		var filtered = Selection.GetFiltered<Material>(SelectionMode.Editable);
		var mats = filtered.Where(m => m.shader == withShader).ToArray();

		foreach (var original in mats)
		{
			TransformMat(original, targetShader, reducer, builder);
		}

		Debug.Log($"[ MaterialConverter.{debugTag}() ] successful transformations: {mats.Length}");
	}

	private static void TransformMat(
		Material original,
		Shader targetShader,
		Func<Material, MatProps> reducer,
		Action<Material, MatProps> builder)
	{
		var destPath = GetSimilarPath(original);
		var props = reducer(original);

		var target = new Material(targetShader);
		builder(target, props);

		AssetDatabase.CreateAsset(target, destPath);
	}

	private static string GetSimilarPath(UnityEngine.Object @object)
	{
		var fullPath = AssetDatabase.GetAssetPath(@object);
		var path = Path.GetDirectoryName(fullPath);
		var ext = Path.GetExtension(fullPath);
		var fromName = Path.GetFileNameWithoutExtension(fullPath);
		var newName = fromName + ".0";
		var newPath = Path.Combine(path, newName) + ext;
		return newPath;
	}
}
