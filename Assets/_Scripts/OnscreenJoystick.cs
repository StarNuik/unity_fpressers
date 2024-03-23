using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using Editor = UnityEngine.SerializeField;

public class OnscreenJoystick : MonoBehaviour //OnScreenControl, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[InputControl(layout = "Vector2")]
	[Editor] string controlPath;

	// private Vector2? start;

	// public void OnBeginDrag(PointerEventData eventData)
	// {
	// 	// unity sends the message multiple times per drag
	// 	if (start.HasValue)
	// 		return;
		
	// 	start = eventData.position;

	// 	Debug.Log("[ OnscreenJoystick.OnBeginDrag ]");
	// }

	// public void OnEndDrag(PointerEventData eventData)
	// {
	// 	start = null;
	// 	SendValueToControl(Vector2.zero);

	// 	Debug.Log("[ OnscreenJoystick.OnEndDrag ]");
	// }

	// public void OnDrag(PointerEventData eventData)
	// {
	// 	if (!start.HasValue)
	// 		return;
		
	// 	var diff = eventData.position - start.Value;
	// 	var dir = diff.normalized;
	// 	SendValueToControl(dir);

	// 	// Debug.Log($"[ OnscreenJoystick.OnDrag ] dir: {dir}");
	// }
	
	// protected override string controlPathInternal
	// {
	// 	get => controlPath;
	// 	set => controlPath = value;
	// }
}
