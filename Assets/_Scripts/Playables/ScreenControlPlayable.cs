using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

[System.Serializable]
public class ScreenControlPlayable : PlayableBehaviour
{
	[Range(0f, 1f)]
	[Editor] float emission;
	[Editor] Material editorOnlyHack;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			ScreenFxController.ApplyTo(editorOnlyHack, emission);
		}
		else
		#endif
		{
			var state = Locator.State;
			state.ScreenEmission = emission;
		}
	}
}
