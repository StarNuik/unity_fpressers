using UnityEngine;
using System.Collections.Generic;

public static class ListExtension
{
	public static T Random<T>(this List<T> list)
	{
		var count = list.Count;
		var idx = UnityEngine.Random.Range(0, count);
		return list[idx];
	}

}