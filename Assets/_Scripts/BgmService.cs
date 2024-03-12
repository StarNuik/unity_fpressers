using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class BgmService : MonoBehaviour
{
	[Editor] AudioSource audio;

	private void Awake()
	{
		Locator.Bgm = this;
	}

	public void Run()
	{
		audio.Stop();
		audio.Play();
	}
}
