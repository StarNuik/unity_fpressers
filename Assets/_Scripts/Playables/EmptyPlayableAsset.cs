using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public abstract class EmptyPlayableAsset<T> : PlayableAsset
	where T : EmptyPlayableAsset<T>
{
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<EmptyPlayable>.Create(graph);
		// var milk = playable.GetBehaviour();
		return playable;
    }

	[System.Serializable]
	public class EmptyPlayable : PlayableBehaviour
	{}
}