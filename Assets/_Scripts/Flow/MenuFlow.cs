using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;
using DG.Tweening;
using Cinemachine;
using UnityEngine.Assertions;

// this file is getting more and more hacky
// pull the `.WaitForInteraction` over here
// to squash 2 routines into 1 ?
public class MenuFlow : MonoBehaviour
{
	[Editor] Image white;
	[Editor] CanvasGroup guiGroup;
	[Editor] CinemachineVirtualCamera vcam;
	[Min(0f)]
	[Editor] float textDelay = 1f;
	[Editor] TextAsset startText;

	private bool isEnabled;
	private bool showText;

	private TextDisplayService textDisplay => Locator.TextDisplay;
	private TranslationService translation => Locator.Translation;
	private ShaderSauceService shader => Locator.ShaderSauce;
	private InputService input => Locator.Input;

	private float fadeinDuration => Consts.MenuFadeinDuration;

	public IEnumerator MenuSequence()
	{
		// INIT
		Assert.IsTrue(!isEnabled);
		isEnabled = true;

		guiGroup.alpha = 1f;
		white.SetAlpha(1f);
		// titleAlpha.PushFromTimeline(1f);
		
		// sort of a hack
		var lastPriority = vcam.Priority;
		vcam.Priority = int.MaxValue;

		// FADE IN
		var tIn = white
			.DOFade(0f, fadeinDuration)
			.SetEase(Consts.W2BTweenEase);
		yield return tIn.WaitForCompletion();

		yield return new WaitForSeconds(textDelay);
		showText = true;

		// WAIT
		yield return input.WaitForInteraction();

		// FADE OUT
		showText = false;

		var outDuration = Consts.TextFadeDuration;
		var tOut = guiGroup
			.DOFade(0f, outDuration)
			.SetEase(Consts.W2BTweenEase);

		yield return tOut.WaitForCompletion();

		vcam.Priority = lastPriority;
		guiGroup.gameObject.SetActive(false);
		isEnabled = false;
	}

	private void Update()
	{
		if (isEnabled)
		{
			shader.PushSplash(1f, 1f);
		}

		// this code is like junk food:
		// cheap and unhealthy
		// in the long run
		// reason: translations
		textDisplay.SplashChannel = showText ? translation.ToString(startText) : null;
	}
}
