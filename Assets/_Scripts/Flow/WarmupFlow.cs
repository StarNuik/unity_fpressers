using System;
using System.Collections;
using System.Collections.Generic;
using DevLocker.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using Editor = UnityEngine.SerializeField;

public class WarmupFlow : MonoBehaviour
{
	[Editor] SceneReference splashScene;
	[Editor] ShaderVariantCollection shaders;

	private void Start()
	{
		StartCoroutine(Flow());
	}

	private IEnumerator Flow()
	{
		// Debug.Log($"[ WarmupFlow.Flow ] shaders.isWarmedUp: {shaders.isWarmedUp}");
		
		while (!shaders.isWarmedUp)
		{
			var f = (float)shaders.warmedUpVariantCount / (float)shaders.variantCount;
			WebPlatform.SendLoadProgress(f);

			// Debug.Log("[ WarmupFlow.Flow ] shaders.WarmUpProgressively");
			shaders.WarmUpProgressively(1);

			yield return null;
		}
		
		WebPlatform.SendLoadProgress(1f);
		WebPlatform.NotifyLoaded();

		// Debug.Log("[WarmupFlow.Flow] LoadScene");

		SceneManager.LoadScene(splashScene.ScenePath);
	}
}
