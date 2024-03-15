using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class DitherTest : MonoBehaviour
{
	[Editor] Material mat;

	[Button]
	private void ResetMat()
	{
		mat.SetFloat("_Dither_Strength", 1f);
	}

	[Button]
	private void Run()
	{
		StartCoroutine(Fade());
	}

	private IEnumerator Fade()
	{
		const float duration = 2f;

		var start = Time.time;
		var end = start + duration;
		while (Time.time <= end)
		{
			var now = Time.time;
			var f = 1f - (now - start) / duration;
			mat.SetFloat("_Dither_Strength", f);
			yield return null;
		}
		mat.SetFloat("_Dither_Strength", 0f);
	}
}
