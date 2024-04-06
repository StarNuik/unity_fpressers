using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Editor = UnityEngine.SerializeField;

public class InputService : MonoBehaviour
{
	[Editor] InputActionAsset actions;

	private InputActionMap map;
	private InputAction move;
	private InputAction look;
	private InputAction interact;
	private InputAction escape;
	private InputAction anykey;

	private AppState state => Locator.State;
	
	public Vector2 Movement
		=> move.ReadValue<Vector2>();

	public Vector2 Camera
		=> look.ReadValue<Vector2>();

	public IEnumerator WaitForInteraction()
	{
		var wait = true;
		Action<InputAction.CallbackContext> action = _ => wait = false;

		interact.performed += action;
		yield return new WaitWhile(() => wait);
		interact.performed -= action;
	}

	public IEnumerator WaitForAnykey()
	{
		var wait = true;
		Action<InputAction.CallbackContext> action = _ => wait = false;

		anykey.performed += action;
		yield return new WaitWhile(() => wait);
		anykey.performed -= action;
	}

	private void Awake()
	{
		Locator.Input = this;

		map = actions.FindActionMap("Player");

		move = map.FindAction("Move");
		look = map.FindAction("Look");
		interact = map.FindAction("Interact");
		escape = map.FindAction("Escape");
		anykey = map.FindAction("AnyKey");

		interact.performed += SendInteract;
		escape.performed += SendEscape;
		// anykey.performed += SendAnykey;
	}


	private void OnDestroy()
	{
		interact.performed -= SendInteract;
		escape.performed -= SendEscape;
		// escape.performed -= SendAnykey;

		
		if (Locator.Input == this)
			Locator.Input = null;
	}

	private void SendInteract(InputAction.CallbackContext _)
	{
		state.InvokeInteractPressed();
	}

	private void SendEscape(InputAction.CallbackContext _)
	{
		state.InvokeEscPressed();
	}

	// private void SendAnykey(InputAction.CallbackContext _)
	// {
	// 	state.InvokeAnykeyPressed();
	// }
}
