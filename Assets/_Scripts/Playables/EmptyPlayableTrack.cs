using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public abstract class EmptyPlayableTrack<T> : TrackAsset
	where T : UnityEngine.Object
{
	public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
	{
		var wrapper = ScriptPlayable<EmptyMixerPlayable>.Create(graph, inputCount);
		
		var instance = wrapper.GetBehaviour();
		instance.ProcessFunc = ProcessFrame;
		
		return wrapper;
	}

	private void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		var target = (T)playerData;
		if (target == null)
			return;
		
		float total = 0f;
		var count = playable.GetInputCount();
		for (int i = 0; i < count; i++)
		{
			var weight = playable.GetInputWeight(i);
			total += weight;
		}

		ApplyWeight(target, total);
	}

	protected abstract void ApplyWeight(T target, float weight);

}

public class EmptyMixerPlayable : PlayableBehaviour
{
	public Action<Playable, FrameData, object> ProcessFunc { get; set; }

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		=> ProcessFunc(playable, info, playerData);
}

