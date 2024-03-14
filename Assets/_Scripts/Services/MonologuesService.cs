using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;
using Monologue = MonologuesContainer.MonologueInfo;

public class MonologuesService : MonoBehaviour
{
	[Editor] MonologuesContainer monologues;

	private Coroutine currentRoutine;
	
	private TextDisplayService textDisplay => Locator.TextDisplay;

	public void ShowMonologueFor(Cutscene cutscene)
	{
		var router = Locator.RouteTracker;
		var info = monologues.GetMonologue(cutscene, router.CurrentRoute);
		
		if (currentRoutine != null)
		{
			StopCoroutine(currentRoutine);
		}
		currentRoutine = StartCoroutine(Show(info));
	}

	private IEnumerator Show(Monologue info)
	{
		textDisplay.MonologueChannel = info.Text;
		yield return new WaitForSeconds(info.Duration);
		textDisplay.MonologueChannel = null;
		
		currentRoutine = null;
	}
}
