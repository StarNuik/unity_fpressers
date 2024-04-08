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
	[Editor] List<CanvasGroup> groups = new();

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

		groups.ForEach(g => g.gameObject.SetActive(false));

		// MAIN "LOOP"
		foreach (var group in groups)
		{
			group.alpha = 0f;
			group.gameObject.SetActive(true);

			var tIn = group
				.DOFade(1f, fadeDuration)
				.SetEase(Consts.B2WTweenEase);

			yield return tIn.WaitForCompletion();

			yield return new WaitForSeconds(groupDuration);

			var tOut = group
				.DOFade(0f, fadeDuration)
				.SetEase(Consts.W2BTweenEase);
			
			yield return tOut.WaitForCompletion();

			group.gameObject.SetActive(false);
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
