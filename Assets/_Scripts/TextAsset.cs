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

	// this is easier to manage in the Editor
	public string ToString(Lang lang)
		=> lang switch {
			Lang.English => english,
			Lang.Russian => russian,
			_ => throw new NotImplementedException(),
		};
}
