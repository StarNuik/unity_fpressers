using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

public class RecordSpin : MonoBehaviour
{
	[Min(0.1f)]
	[Editor] float angularSpeed = 0.1f;

	private void Update()
	{
		transform.Rotate(Vector3.up, angularSpeed * Time.deltaTime, Space.World);
	}
}
