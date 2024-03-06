using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class InteractionHandle : MonoBehaviour
{
	// refs
	[Editor] Outline outline;

	// props
	[Min(0.01f)]
	[Editor] float visibilityNearRadius;
	[Min(0.01f)]
	[Editor] float visibilityFarRadius;

	private float distToPlayer = float.MaxValue;
	private float startWidth;

	public void RegisterPlayerPosition(Vector3 world)
	{
		var pos = transform.position;
		pos.y = 0f;
		world.y = 0f;
		distToPlayer = Vector3.Distance(world, pos);
	}

	public void Activate()
	{
		Debug.Log($"[InteractionHandle.Activate] who: [{outline.name}]");
	}

	private void Awake()
	{
		Locator.InteractionHandles.Add(this);
		startWidth = outline.OutlineWidth;
	}

	private void OnDestroy()
	{
		Locator.InteractionHandles.Remove(this);
	}

	private void Update()
	{
		var dist = Mathf.Clamp(distToPlayer, visibilityNearRadius, visibilityFarRadius);
		var f = Mathf.InverseLerp(visibilityFarRadius, visibilityNearRadius, dist);

		outline.OutlineWidth = Mathf.Lerp(0f, startWidth, f);
		outline.enabled = f > 0.0001f;
	}

	private void OnDrawGizmos()
	{
		var pos = transform.position;
		pos.y = 0f;

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(pos, visibilityNearRadius);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(pos, visibilityFarRadius);
	}
}
