using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;
using DG.Tweening;
using Cinemachine;
public class SplashSequence : MonoBehaviour
{
	[Editor] Image white;
	[Editor] CanvasGroup guiGroup;
	[Editor] CinemachineVirtualCamera vcam;
	[Min(0.1f)]
	[Editor] float fadeinDuration = 1f;
	[Min(0f)]
	[Editor] float textDelay;
	[Editor] TextAsset startText;

	private int lastPriority;
	private bool isEnabled;
	private bool showText;

	private TextDisplayService textDisplay => Locator.TextDisplay;
	private TranslationService translation => Locator.Translation;

	public IEnumerator FadeIn()
	{
		Enable();

		var t = white
			.DOFade(0f, fadeinDuration)
			.SetEase(Ease.OutQuad);
		yield return t.WaitForCompletion();

		yield return new WaitForSeconds(textDelay);

		showText = true;
	}

	public IEnumerator Disable()
	{
		showText = false;
		textDisplay.SplashChannel = null;

		var t = guiGroup
			.DOFade(0f, textDisplay.FadeDuration)
			.SetEase(Ease.OutQuad);
		yield return t.WaitForCompletion();

		vcam.Priority = lastPriority;
		isEnabled = false;
	}

	private void Awake()
	{
		Locator.Splash = this;
		
		// uncomment this if you see a lame frame after the game loads
		// Enable();
	}

	private void Update()
	{
		if (isEnabled)
		{
			Locator.ShaderSauce.PushSplash(1f, 1f);
		}

		// this code is like junk food:
		// cheap and unhealthy
		// in the long run
		if (showText)
		{
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
		
		// sort of a hack
		lastPriority = vcam.Priority;
		vcam.Priority = int.MaxValue;
	}
}
