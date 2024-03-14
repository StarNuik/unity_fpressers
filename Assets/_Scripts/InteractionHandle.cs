using System.Collections;
using System.Collections.Generic;
using ChrisNolet;
using UnityEngine;
using UnityEngine.Serialization;
using Editor = UnityEngine.SerializeField;

public class InteractionHandle : MonoBehaviour
{
	[Editor] List<Outline> outlines = new();

	[field: Editor, Min(0.01f)]
	public float InnerRadius { get; private set; } = 1f;
	[field: Editor, Min(0.01f)]
	public float OuterRadius { get; private set; } = 2f;

	const float epsilon = 0.0001f;

	private Collider collider => GetComponent<Collider>();

	public void TryActivate()
	{
		if (PlayerF() < epsilon)
			return;
		
		foreach (var outline in outlines)
		{
			outline.enabled = false;
			Destroy(outline);
		}
		
		Destroy(collider);
		Destroy(this);
		
		Locator.State.InvokeInteractionTriggered(this);
	}

	public float PlayerF()
	{
		var playerPos = Locator.State.PlayerPosition.ToX0Z();
		var thisPos = transform.position.ToX0Z();
		var distToPlayer = Vector3.Distance(thisPos, playerPos);
		var dist = Mathf.Clamp(distToPlayer, InnerRadius, OuterRadius);
		var f = Mathf.InverseLerp(OuterRadius, InnerRadius, dist);
		return f;
	}

	private void Update()
	{
		var shouldEnable = PlayerF() > epsilon;
		outlines.ForEach(o => o.enabled = shouldEnable);
	}

	private void OnDrawGizmosSelected()
	{
		var pos = transform.position.ToX0Z();

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(pos, InnerRadius);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(pos, OuterRadius);
	}
}
