using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class CutscenesContainer : MonoBehaviour
{
	public Cutscene Intro;
	public Cutscene NeutralEnding;
	[Editor] List<InteractionCutscenePair> interactionCutscenesList = new();

	private Dictionary<InteractionHandle, Cutscene> interactionCutscenes;

	public Cutscene CutsceneOf(InteractionHandle interaction)
		=> interactionCutscenes[interaction];
	
	private void Awake()
	{
		interactionCutscenes = interactionCutscenesList.ToDictionary(p => p.Key, p => p.Value);
		
		Locator.Cutscenes = this;
	}

	[System.Serializable]
	private struct InteractionCutscenePair
	{
		public InteractionHandle Key;
		public Cutscene Value;
	}
}
