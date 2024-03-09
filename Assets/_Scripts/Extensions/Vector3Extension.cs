using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extension
{
	public static Vector2 ToXY(this Vector3 vec)
	{
		return new(vec.x, vec.y);
	}

	public static Vector3 ToX0Z(this Vector3 vec)
	{
		return new(vec.x, 0f, vec.z);
	}
}
