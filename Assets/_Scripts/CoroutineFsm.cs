using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State = System.Func<System.Collections.IEnumerator>;

public abstract class CoroutineFsm : MonoBehaviour
{
	private State pendingTransition;

	protected abstract State Entry { get; }

	protected IEnumerator TransitionTo(State next)
	{
		pendingTransition = next;
		yield break;
	}

	private void Start()
	{
		StartCoroutine(FsmDriver());
	}

	private IEnumerator FsmDriver()
	{
		var next = Entry;
		while (next != null)
		{
			yield return next();
			next = pendingTransition;
			pendingTransition = null;
		}
	}
}
