using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public static class EnhancedTouchSupportExtension
{
	private static List<object> requests = new();

	public static void EnableManaged(object requestee)
	{
		if (requests.Count == 0)
		{
			EnhancedTouchSupport.Enable();
		}

		requests.Add(requestee);
	}

	public static void DisableManaged(object requestee)
	{
		requests.Remove(requestee);

		if (requests.Count == 0)
		{
			EnhancedTouchSupport.Disable();
		}
	}
}
