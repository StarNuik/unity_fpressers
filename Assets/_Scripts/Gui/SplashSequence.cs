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
	[Editor] RectTransform text;
	[Editor] CinemachineVirtualCamera vcam;

	private bool isEnabled;
	private int lastPriority;
	private Vector2 textStart;

	public void Enable()
	{
		if (isEnabled)
			return;

		white.SetAlpha(1f);
		
		textStart = text.anchoredPosition;

		// sort of a hack
		lastPriority = vcam.Priority;
		vcam.Priority = int.MaxValue;

		isEnabled = true;
	}

	public void Disable()
	{
		vcam.Priority = lastPriority;
		isEnabled = false;
	}

	public IEnumerator ClearSplash()
	{
		// just in case
		Enable();

		var t1 = white.DOFade(0f, 1.75f).SetEase(Ease.OutQuad);
		yield return t1.WaitForCompletion();

		var pos = textStart;
		pos.y = -pos.y;

		var t2 = text.DOAnchorPos(pos, 1f).SetEase(Ease.InOutQuad);
		yield return t2.WaitForCompletion();
	}

	public IEnumerator ClearText()
	{
		var t = text.DOAnchorPos(textStart, 1f).SetEase(Ease.InOutQuad);
		yield return t.WaitForCompletion();
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
}
