using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoopCursorService : MonoBehaviour, ICursorService
{
	public bool PreferHidden
	{
		// support for noop-s when?
		set => value = value;
	}

	private void Awake()
	{
		Locator.Cursor = this;
	}
}
