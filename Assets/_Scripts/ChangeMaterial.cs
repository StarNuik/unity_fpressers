using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class ChangeMaterial : MonoBehaviour
{
	[Editor] MeshRenderer renderer;
	[Editor] Material material;

	public void Activate()
	{
		if (!Application.isPlaying)
		{
			Debug.Log("[ ChangeMaterial.Activate ] Is not in Play mode. Returning. ");
			return;
		}
		
		renderer.sharedMaterial = material;
	}
}
