using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Editor = UnityEngine.SerializeField;

public class Cutscene : MonoBehaviour
{
	[Editor] PlayableDirector track;

	public Action Finished;

	private void Awake()
	{
		track.stopped += _ => Finished?.Invoke();
	}

	public void Play()
	{
		track.Play();
	}
}
