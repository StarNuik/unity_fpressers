using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Editor = UnityEngine.SerializeField;

public class PlayerMovement : MonoBehaviour
{
	[Editor] Transform player;
	[Editor] NavMeshAgent navAgent;
	[Editor] float moveSpeed = 1f;

	private AppState state => Locator.State;
	private InputService input => Locator.Input;

	private bool isActive => !state.SuppressPlayer;

	private void Update()
	{
		if (isActive)
		{
			
			var move = input.Movement.ToX0Y();
			
			var worldMove = player.TransformDirection(move);
			var delta = worldMove * moveSpeed * Time.deltaTime;
			navAgent.Move(delta);
		}

		var now = player.position;
		state.DistanceTraveled += Vector3.Distance(now, state.PlayerPosition);
		state.PlayerPosition = now;
	}
}
