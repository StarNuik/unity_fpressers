using System.Collections;
using System.Collections.Generic;
using ChrisNolet;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Editor = UnityEngine.SerializeField;

public class InteractionHandle : MonoBehaviour
{
	[Editor] List<InteractionOutline> outlines = new();
	[Editor] bool isEnabledOnStart = true;
	// not a nasty hack at all \s
	[Editor] UnityEvent onEnable = new();

	[field: Editor, Min(0.01f)]
	public float InnerRadius { get; private set; } = 1f;
	[field: Editor, Min(0.01f)]
	public float OuterRadius { get; private set; } = 2f;

	const float epsilon = 0.0001f;

	private bool isEnabled;

	private Collider collider => GetComponent<Collider>();
	private AppState state => Locator.State;

	public bool IsActive
		=> isEnabled
		&& !state.IsPlayingCutscene
		&& IsCloseEnough();
	
	private void Awake()
	{
		isEnabled = isEnabledOnStart;
	}

	public void Enable()
	{
		isEnabled = true;
		onEnable.Invoke();
	}

	public void TryActivate()
	{
		if (!IsActive)
			return;
		
		outlines.ForEach(o => o.Destroy());

		Destroy(collider);
		// Destroy(this);
		
		Locator.State.InvokeInteractionTriggered(this);
	}

	public bool IsCloseEnough()
		=> PlayerF() > epsilon;

	public float PlayerF()
	{
		var playerPos = Locator.State.PlayerPosition.ToX0Z();
		var thisPos = transform.position.ToX0Z();
		var distToPlayer = Vector3.Distance(thisPos, playerPos);
		var dist = Mathf.Clamp(distToPlayer, InnerRadius, OuterRadius);
		var f = Mathf.InverseLerp(OuterRadius, InnerRadius, dist);
		return f;
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
