using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Editor = UnityEngine.SerializeField;

public class AudioMixerController : MonoBehaviour
{
	[Editor] AudioMixer mixer;
	[Min(0f)]
	[Editor] float decayTimeMax;
	[Editor] AnimationCurve volumeCurve;

	public Props Properties { private get; set; }

	public void Apply()
	{
		SetVolume("Volume.Master", 1f - Properties.MasterDuck);
		SetVolume("Volume.Bgm", 1f - Properties.BgmDuck);
		SetVolume("Send.Bgm2Reverb", Properties.BgmFx);
	}

	private void SetVolume(string name, float f)
	{
		var ff = volumeCurve.Evaluate(f);
		var vol = Mathf.Lerp(-80f, 0f, ff);
		mixer.SetFloat(name, vol);
	}

	public struct Props
	{
		// 0f - 1f
		public float BgmFx;

		// 0f - 1f
		public float MasterDuck;

		// 0f - 1f
		public float BgmDuck;
	}
}