using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(ShaderSauceStrengthAsset))]
[TrackBindingType(typeof(ShaderSauceService))]
public class ShaderSauceStrengthTrack : EmptyPlayableTrack<ShaderSauceService>
{
	protected override void ApplyWeight(ShaderSauceService sauce, float weight)
	{
		sauce.PushTimelineStrength(weight);
	}
}