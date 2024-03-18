using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System;

public static class MaterialConverter
{
	private static Shader gltfShader => Shader.Find("Shader Graphs/glTF-pbrMetallicRoughness");
	private static Shader urpShader => Shader.Find("Universal Render Pipeline/Lit");
	private static Shader urpSimpleShader => Shader.Find("Universal Render Pipeline/Simple Lit");

	[MenuItem("Assets/Convert Material/gltf Pbr -> Urp Lit")]
	public static void GltfToUrp()
	{
		ForEachMat(gltfShader, fromMat => {
			var props = MaterialConversion.FromGltf(fromMat);
			var toMat = new Material(urpShader);
			MaterialConversion.ApplyToUrp(toMat, props);
			return toMat;
		}, "GltfToUrp");
	}

	[MenuItem("Assets/Convert Material/Urp Lit -> Urp Simple Lit")]
	public static void UrpToSimple()
	{
		ForEachMat(urpShader, fromMat => {
			var props = MaterialConversion.FromUrp(fromMat);
			var toMat = new Material(urpSimpleShader);
			MaterialConversion.ApplyToUrpSimple(toMat, props);
			return toMat;
		}, "UrpToSimple");
	}

	private static void ForEachMat(Shader withShader, Func<Material, Material> transform, string debugTag = "ForEachMat")
	{
		var filtered = Selection.GetFiltered<Material>(SelectionMode.Editable);
		var mats = filtered.Where(m => m.shader == withShader).ToArray();

		foreach (var original in mats)
		{
			var destPath = GetSimilarPath(original);

			var target = transform(original);

			AssetDatabase.CreateAsset(target, destPath);
		}

		Debug.Log($"[ MaterialConverter.{debugTag}() ] successful transformations: {mats.Length}");
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
