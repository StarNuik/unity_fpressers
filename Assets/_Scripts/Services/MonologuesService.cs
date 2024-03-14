using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class MonologuesService : MonoBehaviour
{
	[Editor] MonologuesContainer monologues;

	public void ShowMonologueFor(Cutscene cutscene)
	{
		var router = Locator.RouteTracker;
		var info = monologues.GetMonologue(cutscene, router.CurrentRoute);
		
		Debug.Log($"[ MonologuesService.ShowMonologueFor(Cutscene) ] dur: {info.Duration}, text: {info.Text}");
	}
}
