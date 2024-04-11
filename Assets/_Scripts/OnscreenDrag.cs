using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using Editor = UnityEngine.SerializeField;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Screen = UnityEngine.Device.Screen;

public class OnscreenDrag : OnscreenBase
{
	private Vector2 lastPos;
	private int frame = -1;
	private int hits;

	protected override Vector2 FingerDownValue()
	{
		lastPos = activeFinger.currentTouch.screenPosition;
		return default(Vector2);
	}

	protected override Vector2 FingerMoveValue()
	{
		// if (!(activeFinger.lastTouch.valid && activeFinger.currentTouch.valid))
		// 	return default(Vector2);
		var currentPos = activeFinger.currentTouch.screenPosition;
		var delta = currentPos - lastPos;
		
		lastPos = currentPos;
		return delta;
	}

	protected override Vector2 FingerUpValue()
		=> default(Vector2);
}
