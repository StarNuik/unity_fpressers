using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class RenderScaleService : MonoBehaviour
{
	[Editor] FloatPlatformDependent renderScale;

	private void Start()
	{
		var scale = renderScale.Value;
		ScalableBufferManager.ResizeBuffers(scale, scale);
	}
}
