using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(FogMilkRatioAsset))]
[TrackBindingType(typeof(SauceController))]
public class FogMilkRatioTrack : EmptyPlayableTrack<SauceController>
{
	protected override void ApplyWeight(SauceController sauce, float weight)
	{
		sauce.FogMilkRatio = weight;
		sauce.Apply();
	}
}