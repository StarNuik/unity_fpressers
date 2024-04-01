using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fallthrough : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private AppState state => Locator.State;
	
	public void OnPointerDown(PointerEventData _)
	{
		state.InvokeFallthroughPressed();
	}

	public void OnPointerUp(PointerEventData _)
	{
		// throw new System.NotImplementedException();
	}
}
