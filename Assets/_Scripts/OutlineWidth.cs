using System.Collections;
using System.Collections.Generic;
using ChrisNolet;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class OutlineWidth : MonoBehaviour
{
	[Editor] InteractionHandle handle;

	private float startWidth;
	private Outline outline;

	private void Awake()
	{
		outline = GetComponent<Outline>();
		startWidth = outline.OutlineWidth;
	}

	private void Update()
	{
		if (outline == null)
		{
			Destroy(this);
			return;
		}

		outline.OutlineWidth = Mathf.Lerp(0f, startWidth, handle.PlayerF());
	}
}
