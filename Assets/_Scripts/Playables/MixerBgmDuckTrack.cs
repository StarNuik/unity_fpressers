using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackClipType(typeof(MixerBgmDuckAsset))]
[TrackBindingType(typeof(AudioMixerService))]
public class MixerBgmDuckTrack : EmptyPlayableTrack<AudioMixerService>
{
	protected override void ApplyWeight(AudioMixerService target, float weight)
	{
		target.PushBgmDuck(weight);
	}
}
