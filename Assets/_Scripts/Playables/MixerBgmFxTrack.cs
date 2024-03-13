using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

[TrackClipType(typeof(MixerBgmFxAsset))]
[TrackBindingType(typeof(AudioMixerService))]
public class MixerBgmFxTrack : EmptyPlayableTrack<AudioMixerService>
{
	protected override void ApplyWeight(AudioMixerService target, float weight)
	{
		target.PushBgmFx(weight);
	}
}