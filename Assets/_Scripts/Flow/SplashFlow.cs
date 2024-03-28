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
	[Editor] CanvasGroup headphonesGroup;

	[Min(0f)]
	[Editor] float bgFadeDuration = 1f;
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
		headphonesGroup.alpha = 0f;


		// turn this into a list, if doing more than one group
		// MAIN "LOOP"
		var tIn = headphonesGroup
			.DOFade(1f, fadeDuration)
			.SetEase(Consts.B2WTweenEase);

		yield return tIn.WaitForCompletion();

		yield return new WaitForSeconds(groupDuration);

		var tOut = headphonesGroup
			.DOFade(0f, fadeDuration)
			.SetEase(Consts.W2BTweenEase);
		
		yield return tOut.WaitForCompletion();
		
		// BG FADE
		var bgIn = fadeImage
			.DOFade(1f, fadeDuration)
			.SetEase(Consts.B2WTweenEase);
		yield return bgIn.WaitForCompletion();

		// LOAD MAIN SCENE
		SceneManager.LoadScene(roomScene.ScenePath);
	}
}
