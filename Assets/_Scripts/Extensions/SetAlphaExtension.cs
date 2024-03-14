using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class SetAlphaExtension
{
	public static Color WithAlpha(this Color color, float alpha)
	{
		alpha = Mathf.Clamp01(alpha);
		color.a = alpha;
		return color;
	}

	public static void SetAlpha(this Image image, float alpha)
	{
		image.color = image.color.WithAlpha(alpha);
	}

	public static void SetAlpha(this TMP_Text text, float alpha)
	{
		text.color = text.color.WithAlpha(alpha);
	}
}
