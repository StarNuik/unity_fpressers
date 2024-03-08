using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackClipType(typeof(MasterDuckAsset))]
[TrackBindingType(typeof(MixerController))]
public class MasterDuckTrack : EmptyPlayableTrack<MixerController>
{
	protected override void ApplyWeight(MixerController target, float weight)
	{
		target.MasterDuckStrength = weight;
		target.Apply();
	}
}
