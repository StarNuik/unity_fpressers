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
		while (!shaders.isWarmedUp)
		{
			var f = (float)shaders.warmedUpVariantCount / (float)shaders.variantCount;
			WebPlatform.SendLoadProgress(f);

			shaders.WarmUpProgressively(1);

			yield return null;
		}
		
		WebPlatform.SendLoadProgress(1f);
		WebPlatform.NotifyLoaded();

		SceneManager.LoadScene(splashScene.ScenePath);
	}
}
