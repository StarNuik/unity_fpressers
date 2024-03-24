using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

[ExecuteInEditMode]
public class AudioMixerService : MonoBehaviour
{
	[Editor] AudioMixerController audio;

	private AudioMixerController.Props? current;

	private void Awake()
	{
		Locator.AudioMixer = this;
	}

	public void PushBgmDuck(float strength)
	{
		var p = current.GetValueOrDefault();
		p.BgmDuck = strength;
		current = p;
	}

	public void PushMasterDuck(float strength)
	{
		var p = current.GetValueOrDefault();
		p.MasterDuck = strength;
		current = p;
	}

	public void PushBgmFx(float strength)
	{
		var p = current.GetValueOrDefault();
		p.BgmFx = strength;
		current = p;
	}

	private void LateUpdate()
	{
		audio.Properties = current.GetValueOrDefault();
		audio.Apply();
		
		current = null;
	}
}
