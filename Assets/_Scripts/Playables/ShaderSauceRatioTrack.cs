using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(ShaderSauceRatioAsset))]
[TrackBindingType(typeof(ShaderSauceService))]
public class ShaderSauceRatioTrack : EmptyPlayableTrack<ShaderSauceService>
{
	protected override void ApplyWeight(ShaderSauceService sauce, float weight)
	{
		sauce.PushTimelineRatio(weight);
	}
}