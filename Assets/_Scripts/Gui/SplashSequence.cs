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
	[Editor] CinemachineVirtualCamera vcam;
	[Min(0.1f)]
	[Editor] float fadeinDuration = 1f;
	[Min(0f)]
	[Editor] float textDelay;
	[Multiline]
	[Editor] string startText;

	private int lastPriority;
	private bool isEnabled;

	private TextDisplayService textDisplay => Locator.TextDisplay;

	public IEnumerator FadeIn()
	{
		Enable();

		var t = white.DOFade(0f, fadeinDuration).SetEase(Ease.OutQuad);
		yield return t.WaitForCompletion();

		StartCoroutine(DelayText());
	}

	public void Disable()
	{
		vcam.Priority = lastPriority;
		textDisplay.SplashChannel = null;
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
	}

	private void Enable()
	{
		if (isEnabled)
			return;
		
		isEnabled = true;

		white.SetAlpha(1f);
		
		// sort of a hack
		lastPriority = vcam.Priority;
		vcam.Priority = int.MaxValue;
	}

	private IEnumerator DelayText()
	{
		yield return new WaitForSeconds(textDelay);

		// player pressed "F" during the wait
		if (!isEnabled)
			yield break;

		textDisplay.SplashChannel = startText;
	}
}
