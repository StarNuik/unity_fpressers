using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;
using DG.Tweening;
using Cinemachine;

// this file is getting more and more hacky
// pull the `.WaitForInteraction` over here
// to squash 2 routines into 1 ?
public class SplashSequence : MonoBehaviour
{
	[Editor] Image white;
	[Editor] CanvasGroup guiGroup;
	[Editor] CinemachineVirtualCamera vcam;
	[Min(0.1f)]
	[Editor] float fadeinDuration = 1f;
	[Min(0f)]
	[Editor] float textDelay = 1f;
	[Editor] TextAsset startText;

	private int lastPriority;
	private bool isEnabled;
	private bool showText;

	private TextDisplayService textDisplay => Locator.TextDisplay;
	private TranslationService translation => Locator.Translation;
	private TitleAlphaService titleAlpha => Locator.TitleAlpha;
	private ShaderSauceService shader => Locator.ShaderSauce;

	public IEnumerator FadeIn()
	{
		Enable();

		var t = white
			.DOFade(0f, fadeinDuration)
			.SetEase(Consts.B2WTweenEase)
			.OnUpdate(() => titleAlpha.PushFromTimeline(1f));
		yield return t.WaitForCompletion();

		var until = Time.time + textDelay;
		while (Time.time <= until)
		{
			yield return null;
			titleAlpha.PushFromTimeline(1f);
		}

		showText = true;
	}

	public IEnumerator Disable()
	{
		showText = false;
		textDisplay.SplashChannel = null;

		// a hack
		var duration = textDisplay.FadeDuration;

		var seq = DOTween.Sequence();
		seq.Join(guiGroup
			.DOFade(0f, duration)
			.SetEase(Consts.W2BTweenEase)
		);
		seq.Join(DOVirtual
			.Float(1f, 0f, duration, f => titleAlpha.PushFromTimeline(f))
		);

		yield return seq.WaitForCompletion();

		vcam.Priority = lastPriority;
		isEnabled = false;
	}

	private void Awake()
	{
		Locator.Splash = this;
		
		// uncomment this if you see a lame frame when the game loads
		// Enable();
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
		if (showText)
		{
			titleAlpha.PushFromTimeline(1f);
			textDisplay.SplashChannel = translation.ToString(startText);
		}
	}

	private void Enable()
	{
		if (isEnabled)
			return;
		
		isEnabled = true;

		white.SetAlpha(1f);
		guiGroup.alpha = 1f;
		titleAlpha.PushFromTimeline(1f);
		
		// sort of a hack
		lastPriority = vcam.Priority;
		vcam.Priority = int.MaxValue;
	}
}
