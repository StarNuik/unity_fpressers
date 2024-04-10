using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;
using Editor = UnityEngine.SerializeField;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class OnscreenJoystick : OnscreenDrag
{
	[Editor] Image stickBg;
	[Editor] Image stickFg;
	[Editor] float stickRange;

	protected override Vector2 FingerDownValue()
	{
		var finger = activeFinger;
		stickBg.gameObject.SetActive(true);
		stickBg.rectTransform.anchoredPosition = ToCanvas(
			GetComponent<RectTransform>(),
			finger.screenPosition
		);

		return default(Vector2);
	}

	protected override Vector2 FingerMoveValue()
	{
		var finger = activeFinger;
		var stickPos = ToCanvas(stickBg.rectTransform, finger.screenPosition);
		var dir = stickPos.normalized;
		var length = Mathf.Min(stickRange, stickPos.magnitude);
		var clamped = dir * length;

		stickFg.rectTransform.anchoredPosition = clamped;
		return clamped / stickRange;
	}

	protected override Vector2 FingerUpValue()
	{
		stickBg.gameObject.SetActive(false);
		stickFg.rectTransform.anchoredPosition = Vector2.zero;

		return default(Vector2);
	}
}
