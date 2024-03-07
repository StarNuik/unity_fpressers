using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(BgmFunkAsset))]
[TrackBindingType(typeof(BgmFxController))]
public class BgmFunkTrack : EmptyPlayableTrack<BgmFxController>
{
	protected override void ApplyWeight(BgmFxController target, float weight)
	{
		target.Apply(weight);
	}
}