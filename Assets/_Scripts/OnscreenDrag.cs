using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using Editor = UnityEngine.SerializeField;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using Screen = UnityEngine.Device.Screen;

public class OnscreenDrag : OnScreenControl
{
	[Editor] Bounds activationBounds;
	[InputControl(layout = "Vector2")]
	[Editor] string controlPath;

	protected override string controlPathInternal
	{
		get => controlPath;
		set => controlPath = value;
	}

	protected Finger activeFinger;

	protected override void OnEnable()
	{
		base.OnEnable();

		EnhancedTouchSupportExtension.EnableManaged(this);
		Touch.onFingerDown += OnFingerDown;
		Touch.onFingerMove += OnFingerMove;
		Touch.onFingerUp += OnFingerUp;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		Touch.onFingerDown -= OnFingerDown;
		Touch.onFingerMove -= OnFingerMove;
		Touch.onFingerUp -= OnFingerUp;
		EnhancedTouchSupportExtension.DisableManaged(this);

		activeFinger = null;
		SendValueToControl(default(Vector2));
	}

	private void OnFingerDown(Finger finger)
	{
		if (activeFinger != null)
			return;
		
		var sizeReverse = new Vector3(1f / Screen.width, 1f / Screen.height, 0f);
		var pos = Vector2.Scale(finger.screenPosition, sizeReverse);

		if (!activationBounds.Contains(pos))
			return;
		
		activeFinger = finger;

		SendValueToControl(FingerDownValue());
	}

	private void OnFingerMove(Finger finger)
	{
		if (activeFinger == null || finger != activeFinger)
			return;
		
		SendValueToControl(FingerMoveValue());
	}

	private void OnFingerUp(Finger finger)
	{
		if (activeFinger == null || finger != activeFinger)
			return;

		activeFinger = null;
		SendValueToControl(FingerUpValue());
	}

	protected virtual Vector2 FingerDownValue()
		=> default(Vector2);

	protected virtual Vector2 FingerMoveValue()
	{
		if (!(activeFinger.lastTouch.valid && activeFinger.currentTouch.valid))
			return default(Vector2);
		
		var delta = activeFinger.currentTouch.delta;
		return delta;
	}

	protected virtual Vector2 FingerUpValue()
		=> default(Vector2);

	protected Vector2 ToCanvas(RectTransform rect, Vector2 screenPos)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			rect, screenPos, null, out var anchored
		);
		return anchored;
	}

	private void OnDrawGizmos()
	{
		var size = new Vector3(Screen.width, Screen.height, 0f);
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(
			Vector3.Scale(activationBounds.center, size),
			Vector3.Scale(activationBounds.size, size)
		);
	}
}