using UnityEngine;

public class AppState
{
	public bool SuppressPlayer = false;
	public bool IsPlayingCutscene = false;
	public Cutscene PendingInteraction = null;

	public float ScreenEmission = 0f;
	public Vector3 PlayerPosition;
}