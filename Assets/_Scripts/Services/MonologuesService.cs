using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class MonologuesService : MonoBehaviour
{
	[Editor] MonologuesContainer monologues;

	private Coroutine currentRoutine;
	
	private TextDisplayService textDisplay => Locator.TextDisplay;
	private TranslationService translation => Locator.Translation;

	public void ShowMonologueFor(Cutscene cutscene)
	{
		var router = Locator.RouteTracker;
		var text = monologues.GetMonologue(cutscene, router.CurrentRoute);
		
		if (currentRoutine != null)
		{
			StopCoroutine(currentRoutine);
		}
		currentRoutine = StartCoroutine(Show(text));
	}

	private IEnumerator Show(TextAsset text)
	{
		textDisplay.MonologueChannel = translation.ToString(text);
		yield return new WaitForSeconds(text.PreferredDuration);
		textDisplay.MonologueChannel = null;
		
		currentRoutine = null;
	}
}
