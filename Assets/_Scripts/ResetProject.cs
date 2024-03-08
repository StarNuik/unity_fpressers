using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;

// this is a REALLY UGLY hack
public class ResetProject : MonoBehaviour
{
	[Editor] MixerController mixer;
	[Editor] SauceController sauce;
	[Editor] Image white;
	[Editor] Image black;
	[Editor] Material screen;

	[Button]
	private void Reset()
	{
		mixer.BgmSauceStrength = 0f;
		mixer.MasterDuckStrength = 0f;
		mixer.Apply();

		sauce.Strength = 0f;
		sauce.FogMilkRatio = 0f;
		sauce.Apply();

		white.SetAlpha(0f);
		black.SetAlpha(0f);

		screen.SetColor("_EmissionColor", Color.black);
	}
}
