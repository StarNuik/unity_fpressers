using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

[ExecuteInEditMode]
public class TitleAlphaService : PushTargetMonoBehaviour
{
	[Editor] TMP_Text text;

	private float? current;

	public override void PushFromTimeline(float value)
	{
		current = value;
	}

	private void Awake()
	{
		Locator.TitleAlpha = this;
	}

	private void LateUpdate()
	{
		var f = current.GetValueOrDefault();
		var ff = Consts.B2WCurve(f);
		text.SetAlpha(ff);

		current = null;
	}
}
