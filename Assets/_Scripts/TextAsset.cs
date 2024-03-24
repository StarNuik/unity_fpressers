using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Editor = UnityEngine.SerializeField;
using Lang = TranslationService.Language;

[CreateAssetMenu(menuName = "SOs/Text")]
public class TextAsset : ScriptableObject
{
	[Multiline]
	[Editor] string english;
	[Multiline]
	[Editor] string russian;
	[Min(1f)]
	[Editor] float preferredDuration = 1f;

	public float PreferredDuration => preferredDuration;

	// the code is hacky
	// but this way it is easier to manage texts in the Editor
	public string ToString(Lang lang)
		=> lang switch {
			Lang.English => english,
			Lang.Russian => russian,
			_ => throw new NotImplementedException(),
		};
}
