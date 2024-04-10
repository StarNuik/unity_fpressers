using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class TouchscreenOverlayService : MonoBehaviour
{
	[Editor] OnscreenDrag look;
	[Editor] OnscreenJoystick move;
	[Editor] RectTransform parent;

	private AppState state => Locator.State;

	private void Start()
	{
		parent.gameObject.SetActive(Platform.IsHandheld);
	}

	private void Update()
	{
		var canControlPlayer = !state.SuppressPlayer;
		look.gameObject.SetActive(canControlPlayer);
		move.gameObject.SetActive(canControlPlayer);
	}
}
