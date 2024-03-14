using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
	public bool IsInteractUp => Input.GetKeyUp(KeyCode.F);

	public Vector2 Movement
	{
		get
		{
			var vec = Vector2.zero;
			vec.y += Input.GetKey(KeyCode.W) ? 1f : 0f;
			vec.y += Input.GetKey(KeyCode.S) ? -1f : 0f;
			vec.x += Input.GetKey(KeyCode.D) ? 1f : 0f;
			vec.x += Input.GetKey(KeyCode.A) ? -1f : 0f;
			return vec;
		}
	}

	// pixel delta
	public Vector2 Camera
	{
		get => new(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}

	private void Awake()
	{
		Locator.Input = this;
	}
}
