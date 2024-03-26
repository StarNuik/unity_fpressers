using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;

// this is a REALLY UGLY hack
public class ResetProject : MonoBehaviour
{
	[Editor] Image white;
	[Editor] Image black;
	[Editor] Image splash;

	[Button]
	private void Reset()
	{
		white.SetAlpha(0f);
		black.SetAlpha(0f);
		splash.SetAlpha(0f);
	}

	[Button]
	private void Release()
	{
		splash.SetAlpha(1f);
		white.SetAlpha(0f);
		black.SetAlpha(0f);
	}
}
