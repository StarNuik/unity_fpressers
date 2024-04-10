using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;

[CreateAssetMenu(menuName = "SOs/Float (Platform Dependent)", fileName = "Float")]
public class FloatPlatformDependent : ScriptableObject
{
	[Editor] float handheld;
	[Editor] float desktop;

	public float Value
		=> Platform.SwitchIfHandheld(handheld, desktop);
}
