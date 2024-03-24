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
	private AppState state => Locator.State;

	private bool isActive => !Locator.State.SuppressPlayer;

	private void OnEnable()
	{
		state.InteractPressed += TryInteraction;
	}

	private void OnDisable()
	{
		state.InteractPressed -= TryInteraction;
	}

	private void Update()
	{
		if (!isActive)
			return;
		
		UpdateTarget();
		UpdateHover();
	}

	private void UpdateTarget()
	{
		var ray = new Ray(playerLens.position, playerLens.forward);
		
		Physics.Raycast(ray, out var hit, 10f, interactionLayer);
		target = hit.collider?.GetComponent<InteractionHandle>();
	}

	private void UpdateHover()
	{
		state.IsInteractionHovered = target != null && target.IsCloseEnough();
	}

	private void TryInteraction()
	{
		target?.TryActivate();
	}
}
