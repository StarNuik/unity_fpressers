using System.Collections;
using System.Collections.Generic;
using DevLocker.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;

public class SplashFlow : MonoBehaviour
{
	[Editor] SceneReference roomScene;
	[Editor] Image fadeImage;
	[Editor] Image logoImage;
	[Editor] CanvasGroup headphonesGroup;

	[Min(0f)]
	[Editor] float fadeDuration = 1f;
	[Min(0.1f)]
	[Editor] float groupDuration = 1f;

	private void Start()
	{
		StartCoroutine(Flow());
	}

	private IEnumerator Flow()
	{
		// SETUP
		fadeImage.SetAlpha(0f);
		logoImage.SetAlpha(0f);

		headphonesGroup.alpha = 0f;

		// setup a logo fade
		// runs in parallel
		var tLogo = logoImage
			.DOFade(1f, fadeDuration)
			.SetEase(Consts.B2WTweenEase);

		// turn this into a list, if doing more than one group
		// MAIN "LOOP"
		var group = headphonesGroup;
		{
			var tIn = group
				.DOFade(1f, fadeDuration)
				.SetEase(Consts.B2WTweenEase);

			yield return tIn.WaitForCompletion();

			yield return new WaitForSeconds(groupDuration);

			var tOut = group
				.DOFade(0f, fadeDuration)
				.SetEase(Consts.W2BTweenEase);
			
			yield return tOut.WaitForCompletion();
		}
		
		// BG FADE
		var bgIn = fadeImage
			.DOFade(1f, fadeDuration)
			.SetEase(Consts.B2WTweenEase);
		yield return bgIn.WaitForCompletion();

		// LOAD MAIN SCENE
		SceneManager.LoadScene(roomScene.ScenePath);
	}
}
