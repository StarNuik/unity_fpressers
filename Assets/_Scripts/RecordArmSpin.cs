using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;
using DG.Tweening;
public class RecordArmSpin : MonoBehaviour
{
	[Min(1f)]
	[Editor] float duration = 1f;
	[Editor] float angleAdd;

	private void Start()
	{
		var angles = transform.rotation.eulerAngles;
		angles.y += angleAdd;

		transform
			.DORotate(angles, duration)
			.SetEase(Ease.Linear);
	}
}
