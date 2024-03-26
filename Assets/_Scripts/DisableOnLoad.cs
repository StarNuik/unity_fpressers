using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnLoad : MonoBehaviour
{
	private void Update()
	{
		gameObject.SetActive(false);
		Destroy(this);
	}
}
