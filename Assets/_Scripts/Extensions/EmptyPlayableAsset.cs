using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

[System.Serializable]
public abstract class EmptyPlayableAsset<T> : PlayableAsset
	where T : EmptyPlayableAsset<T>
{
	[Editor] SharedPlayable template;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<SharedPlayable>.Create(graph, template);
		return playable;
    }

	// [System.Serializable]
	// private class GenericPlayable : EmptyPlayable
	// {}
}

[System.Serializable]
public class SharedPlayable : PlayableBehaviour
{
	[Range(0f, 1f)]
	public float Intensity = 1f;
}