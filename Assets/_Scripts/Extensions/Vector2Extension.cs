using UnityEngine;

public static class Vector2Extension
{
	public static Vector3 ToX0Y(this Vector2 vec)
	{
		return new(vec.x, 0f, vec.y);
	}
}