using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class CutscenesContainer : MonoBehaviour
{
	[field: Editor]
	public Cutscene Intro { get; private set; }
	[field: Editor]
	public Cutscene MainEnding { get; private set; }
	
	private void Awake()
	{
		Locator.Cutscenes = this;
	}
}
