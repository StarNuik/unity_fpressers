using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(SauceStrengthAsset))]
[TrackBindingType(typeof(SauceController))]
public class SauceStrengthTrack : EmptyPlayableTrack<SauceController>
{
	protected override void ApplyWeight(SauceController sauce, float weight)
	{
		sauce.Strength = weight;
		sauce.Apply();
		
		Locator.State.ShaderSauceIsTimelined = weight > 0f;
	}
}