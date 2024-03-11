using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class BgmService : MonoBehaviour
{
	[Editor] AudioSource audio;
	[Editor] float delay;

	private void Awake()
	{
		Locator.Bgm = this;
	}

	public IEnumerator WaitForStart()
	{
		audio.Stop();

		yield return new WaitForSeconds(delay);
		
		audio.Play();
	}
}
