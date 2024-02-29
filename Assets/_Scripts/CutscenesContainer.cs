using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class CutscenesContainer : MonoBehaviour
{
	[field: Editor]
	public Cutscene GameStart { get; private set; }
	
	private void Awake()
	{
		Locator.Cutscenes = this;
	}
}
