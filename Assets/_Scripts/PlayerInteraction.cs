using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class PlayerInteraction : MonoBehaviour
{
	[Editor] Transform player;
	[Editor] Transform playerLens;
	[Editor] LayerMask interactionLayer;

	private InteractionHandle target;

	private void Update()
	{
		UpdateHandles();
		UpdateTarget();
		UpdateInput();
	}

	private void UpdateInput()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			target?.Activate();
		}
	}

	private void UpdateTarget()
	{
		var ray = new Ray(playerLens.position, playerLens.forward);
		
		Physics.Raycast(ray, out var hit, 10f, interactionLayer);
		target = hit.collider?.GetComponent<InteractionHandle>();
	}

	private void UpdateHandles()
	{
		foreach (var handle in Locator.InteractionHandles)
		{
			handle.RegisterPlayerPosition(player.position);
		}
	}
}
