using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

[System.Serializable]
public class PcScreenTextureAsset : PlayableAsset
{
	[Editor] PcScreenTexturePlayable template;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<PcScreenTexturePlayable>.Create(graph, template);
		return playable;
    }
}

[System.Serializable]
public class PcScreenTexturePlayable : PlayableBehaviour
{
	[Editor] Texture2D texture;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		var target = (PcScreenMaterialService)playerData;

		target.PushTexture(texture);
	}
}