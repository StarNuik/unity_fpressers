using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Editor = UnityEngine.SerializeField;

[CreateAssetMenu(menuName = "SOs/Bgm Fx Controller")]
public class MixerController : ScriptableObject
{
	[Editor] AudioMixer mixer;
	[Min(0f)]
	[Editor] float decayTimeMax;
	[Editor] AnimationCurve volumeCurve;

	public float BgmSauceStrength { get; set; } = 0f;
	public float MasterDuckStrength { get; set; } = 0f;

	public void Apply()
	{
		SetVolume("Volume.Master", 1f - MasterDuckStrength);
		ApplyBgmSauce();
	}

	private void ApplyBgmSauce()
	{
		var decay = Mathf.Lerp(0f, decayTimeMax, BgmSauceStrength);
		mixer.SetFloat("DecayTime.BGM", decay);

		SetVolume("Wet.BGM", BgmSauceStrength);
	}

	private void SetVolume(string name, float f)
	{
		var ff = volumeCurve.Evaluate(f);
		var vol = Mathf.Lerp(-80f, 0f, ff);
		mixer.SetFloat(name, vol);
	}
}
