using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

[System.Serializable]
public class MilkControlPlayable : PlayableBehaviour
{
	[Range(0f, 1f)]
	[Editor] float strength;
	[Range(0f, 1f)]
	[Editor] float fogMilkRatio;
	[Editor] Material editorOnlyHack;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			MilkFxController.ApplyTo(editorOnlyHack, strength, fogMilkRatio);
		}
		else
		#endif
		{
			var state = Locator.State;
			state.MilkStrength = strength;
			state.FogMilkRatio = fogMilkRatio;
		}
	}
}
