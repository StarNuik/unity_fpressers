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

	private InputService input => Locator.Input;

	private bool isActive => !Locator.State.SuppressPlayer;

	private void Update()
	{
		UpdateTarget();
		UpdateInput();
	}

	private void UpdateTarget()
	{
		var ray = new Ray(playerLens.position, playerLens.forward);
		
		Physics.Raycast(ray, out var hit, 10f, interactionLayer);
		target = hit.collider?.GetComponent<InteractionHandle>();
	}

	private void UpdateInput()
	{
		if (isActive && input.IsInteractUp)
		{
			target?.Activate();
		}
	}
}
