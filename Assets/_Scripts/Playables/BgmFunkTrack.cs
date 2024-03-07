using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(BgmFunkAsset))]
[TrackBindingType(typeof(MixerController))]
public class BgmFunkTrack : EmptyPlayableTrack<MixerController>
{
	protected override void ApplyWeight(MixerController target, float weight)
	{
		target.BgmSauceStrength = weight;
		target.Apply();
	}
}