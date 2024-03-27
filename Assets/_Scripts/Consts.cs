using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public static class Consts
{
	public static float B2WCurve(float time)
		=> Mathf.Pow(Mathf.Clamp01(time), 2.33f);
	
	public static float W2BCurve(float time)
		=> 1f - Mathf.Pow(1f - Mathf.Clamp01(time), 2.33f);
	
	public static float B2WTweenEase(float time, float duration, float overshootOrAmplitude, float period)
		=> B2WCurve(time / duration);

	public static float W2BTweenEase(float time, float duration, float overshootOrAmplitude, float period)
		=> W2BCurve(time / duration);
}
