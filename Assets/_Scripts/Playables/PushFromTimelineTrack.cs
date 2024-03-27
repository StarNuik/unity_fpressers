using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackClipType(typeof(PushFromTimelineAsset))]
[TrackBindingType(typeof(PushTargetMonoBehaviour))]
public class PushFromTimelineTrack : EmptyPlayableTrack<PushTargetMonoBehaviour>
{
	protected override void ApplyWeight(PushTargetMonoBehaviour target, float weight)
	{
		target.PushFromTimeline(weight);
	}
}
