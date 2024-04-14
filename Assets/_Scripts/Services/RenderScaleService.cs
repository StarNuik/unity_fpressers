using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Editor = UnityEngine.SerializeField;

public class RenderScaleService : MonoBehaviour
{
	[Editor] UniversalRenderPipelineAsset pipeline;
	[Editor] FloatPlatformDependent renderScale;

	private void Start()
	{
		var scale = renderScale.Value;
		pipeline.renderScale = scale;
	}
}
