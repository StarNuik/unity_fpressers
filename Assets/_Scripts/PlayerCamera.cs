using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class PlayerCamera : MonoBehaviour
{
	[Editor] Transform rotationTargetY;
	[Editor] Transform rotationTargetX;
	[Editor] float mouseSensitivity = 1f;

	private float targetX;
	private float targetY;
	
	private AppState state => Locator.State;
	private InputService input => Locator.Input;

	private bool isSuppressed => Locator.State.SuppressPlayer;

	private void Update()
	{
		if (isSuppressed)
			return;
		
		var delta = input.Camera;
		state.CameraPixelsTraveled += delta.magnitude;

		// camera Y
		targetY = Mathf.Repeat(targetY + delta.x * mouseSensitivity, 360f);
		{
			var euler = rotationTargetY.localEulerAngles;
			euler.y = targetY;
			rotationTargetY.localEulerAngles = euler;
		}

		// camera X
		targetX = Mathf.Clamp(targetX + -delta.y * mouseSensitivity, -89.9f, 89.9f);
		{
			var euler = rotationTargetX.localEulerAngles;
			euler.x = targetX;
			rotationTargetX.localEulerAngles = euler;
		}
	}
}
