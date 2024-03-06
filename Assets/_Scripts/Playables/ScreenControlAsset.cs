using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

[System.Serializable]
public class ScreenControlAsset : PlayableAsset
{
	[Editor] ScreenControlPlayable template;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        return ScriptPlayable<ScreenControlPlayable>.Create(graph, template);
    }
}
