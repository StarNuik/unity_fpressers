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

	private Vector2 lastMouse;
	private float targetX;
	private float targetY;
	
	private bool isSuppressed => AppState.SuppressPlayer;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
	}

	private void Update()
	{
		if (Time.frameCount < 5)
		{
			lastMouse = Input.mousePosition;
			return;
		}

		if (isSuppressed)
			return;
		
		var now = Input.mousePosition.ToXY();
		var delta = now - lastMouse;

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

		// 
		lastMouse = now;
	}
}
