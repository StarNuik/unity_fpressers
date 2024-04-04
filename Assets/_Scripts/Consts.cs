using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public static class Consts
{
	public const float Epsilon = 0.0001f;
	
	public static float B2WCurve(float time)
		=> Mathf.Pow(Mathf.Clamp01(time), 2.33f);
	
	public static float W2BCurve(float time)
		=> 1f - Mathf.Pow(1f - Mathf.Clamp01(time), 2.33f);
	
	public static float B2WTweenEase(float time, float duration, float overshootOrAmplitude, float period)
		=> B2WCurve(time / duration);

	public static float W2BTweenEase(float time, float duration, float overshootOrAmplitude, float period)
		=> W2BCurve(time / duration);
	
	// is it getting better or worse? (56dc202622252c675fcab177573e3274b7c86a0a:TextDisplayService.cs:31)
	public const float TextFadeDuration = 0.5f;

	// definetely worse (56dc202622252c675fcab177573e3274b7c86a0a:MenuFlow.cs:19)
	public const float MenuFadeinDuration = 1f;
}
