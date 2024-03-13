using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class FootstepsService : MonoBehaviour
{
	[Editor] List<AudioClip> clips;
	[Editor] AudioSource audioSource;
	
	[Min(0.01f)]
	[Editor] float distPerStep;

	private int lastStep;

	private AppState state => Locator.State;
	private bool isActive => !state.SuppressPlayer;

	private void Update()
	{
		var step = Mathf.FloorToInt(state.DistanceTraveled / distPerStep);
		if (isActive && step > lastStep)
		{
			PlayStep();
		}

		lastStep = step;
	}

	private void PlayStep()
	{
		var clip = clips.Random();
		audioSource.PlayOneShot(clip);
	}
}
