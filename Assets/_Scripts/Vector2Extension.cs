using UnityEngine;

public static class Vector2Extension
{
	public static Vector2 ToXY(this Vector3 vec)
	{
		return new(vec.x, vec.y);
	}
}