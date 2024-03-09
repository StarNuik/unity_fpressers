using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class InteractionHandle : MonoBehaviour
{
	[Editor] List<Outline> outlines = new();
	[Editor] Cutscene cutscene;

	[field: Editor, Min(0.01f)]
	public float InnerRadius { get; private set; } = 1f;
	[field: Editor, Min(0.01f)]
	public float OuterRadius { get; private set; } = 2f;

	private Collider collider => GetComponent<Collider>();

	public void Activate()
	{
		var state = Locator.State;
		if (state.PendingInteraction != null)
			return;
		
		foreach (var outline in outlines)
		{
			outline.enabled = false;
			Destroy(outline);
		}
		state.PendingInteraction = cutscene;
		Destroy(collider);
		Destroy(this);
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

	private void Awake()
	{
		Locator.InteractionHandles.Add(this);
	}

	private void OnDestroy()
	{
		Locator.InteractionHandles.Remove(this);
	}

	private void Update()
	{
		var shouldEnable = PlayerF() > 0.0001f;
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
