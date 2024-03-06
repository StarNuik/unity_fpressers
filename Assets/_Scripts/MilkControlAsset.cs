using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

[System.Serializable]
public class MilkControlAsset : PlayableAsset
{
	[Editor] MilkControlPlayable template;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<MilkControlPlayable>.Create(graph, template);

		var milk = playable.GetBehaviour();

		return playable;
    }
}
