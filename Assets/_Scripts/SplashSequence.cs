using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;
using DG.Tweening;
public class SplashSequence : MonoBehaviour
{
	[Editor] Image white;
	[Editor] RectTransform text;

	public void Prepare()
	{
		white.SetAlpha(1f);
		var pos = text.anchoredPosition;
		pos.y = -pos.y;
		text.anchoredPosition = pos;
	}

	public IEnumerator FadeIn()
	{
		Prepare();

		var t1 = white.DOFade(0f, 1f).SetEase(Ease.OutQuad);
		yield return t1.WaitForCompletion();

		var pos = text.anchoredPosition;
		pos.y = -pos.y;
		var t2 = text.DOAnchorPos(pos, 1f).SetEase(Ease.InOutQuad);
		yield return t2.WaitForCompletion();
	}

	public IEnumerator Clear()
	{
		var pos = text.anchoredPosition;
		pos.y = -pos.y;
		var t = text.DOAnchorPos(pos, 1f).SetEase(Ease.InOutQuad);
		yield return t.WaitForCompletion();
	}
}
