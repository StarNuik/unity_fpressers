using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

[TrackClipType(typeof(ImageAlphaAsset))]
[TrackBindingType(typeof(Image))]
public class ImageAlphaTrack : EmptyPlayableTrack<Image>
{
	protected override void ApplyWeight(Image target, float weight)
	{
		var color = target.color;
		color.a = weight;
		target.color = color;
	}
}
