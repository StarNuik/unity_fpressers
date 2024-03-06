using System;
using UnityEngine;

public class ReplacedMaterial
{
	private Material last;
	private Material current;

	public Material Value => current;

	private Func<Material> get;
	private Action<Material> set;

	public ReplacedMaterial(Func<Material> get, Action<Material> set)
	{
		this.get = get;
		this.set = set;

		last = get();
		current = new(last);
		set(current);
	}

	public void Return()
	{
		set(last);
		UnityEngine.Object.Destroy(current);
	}

	//* slightly unsafe
	public static implicit operator Material(ReplacedMaterial from)
	{
		return from.Value;
	}
}