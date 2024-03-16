using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackClipType(typeof(PcScreenEmissionAsset))]
[TrackBindingType(typeof(PcScreenMaterialService))]
public class PcScreenEmissionTrack : EmptyPlayableTrack<PcScreenMaterialService>
{
	
	protected override void ApplyWeight(PcScreenMaterialService target, float weight)
	{
		target.PushStrength(weight);
	}
}
