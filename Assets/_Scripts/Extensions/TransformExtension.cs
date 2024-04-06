using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
	/// <summary>
	/// scale is ignored
	/// </summary>
	public static void Lerp(this Transform target, Transform from, Transform to, float time)
	{
		var pos = Vector3.Lerp(from.position, to.position, time);
		var rot = Quaternion.Slerp(from.rotation, to.rotation, time);
		target.position = pos;
		target.rotation = rot;
	}
}
