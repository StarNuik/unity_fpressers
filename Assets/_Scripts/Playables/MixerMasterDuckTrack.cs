using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackClipType(typeof(MixerMasterDuckAsset))]
[TrackBindingType(typeof(AudioMixerService))]
public class MixerMasterDuckTrack : EmptyPlayableTrack<AudioMixerService>
{
	protected override void ApplyWeight(AudioMixerService target, float weight)
	{
		target.PushMasterDuck(weight);
	}
}
