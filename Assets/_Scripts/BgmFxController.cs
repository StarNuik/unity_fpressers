using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Editor = UnityEngine.SerializeField;

[CreateAssetMenu(menuName = "SOs/Bgm Fx Controller")]
public class BgmFxController : ScriptableObject
{
	[Editor] AudioMixer mixer;
	[Min(0f)]
	[Editor] float decayTimeMax;
	[Editor] AnimationCurve volumeCurve;

	public void Apply(float strength)
	{
		var decay = Mathf.Lerp(0f, decayTimeMax, strength);
		mixer.SetFloat("DecayTime.BGM", decay);

		var reverbF = volumeCurve.Evaluate(strength);
		var reverb = Mathf.Lerp(-10000f, 0f, reverbF);
		mixer.SetFloat("ReverbVolume.BGM", reverb);

		var overlayF = volumeCurve.Evaluate(1f - strength);
		var overlay = Mathf.Lerp(-2500f, 0f, overlayF);
		mixer.SetFloat("OverlayVolume.BGM", overlay);
	}
}
