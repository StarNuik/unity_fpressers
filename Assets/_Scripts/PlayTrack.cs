using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class PlayTrack : MonoBehaviour
{
	[Editor] AudioSource audio;
	[Editor] float delay;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(delay);
		audio.Play();
	}
}
