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

	private bool isSuppressed => Locator.State.SuppressPlayer;

	private void Update()
	{
		if (isSuppressed)
			return;
			
		var move = Vector3.zero;
		move.z += Input.GetKey(KeyCode.W) ? 1f : 0f;
		move.z += Input.GetKey(KeyCode.S) ? -1f : 0f;
		move.x += Input.GetKey(KeyCode.D) ? 1f : 0f;
		move.x += Input.GetKey(KeyCode.A) ? -1f : 0f;
		
		var worldMove = player.TransformDirection(move);
		var delta = worldMove * moveSpeed * Time.deltaTime;
		navAgent.Move(delta);
	}
}
