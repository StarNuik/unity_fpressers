using System.Collections;
using System.Collections.Generic;
using ChrisNolet;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class InteractionOutline : MonoBehaviour
{
	[Editor] InteractionHandle handle;
	[Editor] AnimationCurve curve;

	private Outline driver;
	private float startWidth;

	public void Destroy()
	{
		driver.enabled = false;
		Destroy(driver);
		Destroy(this);
	}

	private void Awake()
	{
		driver = GetComponent<Outline>();
		startWidth = driver.OutlineWidth;
	}

	private void Update()
	{
		driver.OutlineWidth = Mathf.Lerp(0f, startWidth, curve.Evaluate(handle.PlayerF()));
		driver.enabled = handle.IsActive;
	}
}
